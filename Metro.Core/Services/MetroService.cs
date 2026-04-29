using Metro.Core.DTOs;
using Metro.Core.Exceptions;
using Metro.Core.Interfaces;

namespace Metro.Core.Services;

public class MetroService : IMetroService
{
    private readonly IRouteService _routeService;
    private readonly ITravelTimeService _travelTimeService;
    private readonly IPricingService _pricingService;
    private readonly ITransferDetectionService _transferDetectionService;
    private readonly IStationRepository _stationRepository;
    private readonly IPricingRuleRepository _pricingRuleRepository;

    public MetroService(
        IRouteService routeService,
        ITravelTimeService travelTimeService,
        IPricingService pricingService,
        ITransferDetectionService transferDetectionService,
        IStationRepository stationRepository,
        IPricingRuleRepository pricingRuleRepository)
    {
        _routeService = routeService;
        _travelTimeService = travelTimeService;
        _pricingService = pricingService;
        _transferDetectionService = transferDetectionService;
        _stationRepository = stationRepository;
        _pricingRuleRepository = pricingRuleRepository;
    }

    public async Task<RouteResultDto> GetRouteAsync(int startId, int endId)
    {
        // ── Validation ──────────────────────────────────────────────────────
        if (startId == endId)
            throw new InvalidRouteException("Start station and end station must be different.");

        // ── Resolve station entities (IDs → names) ──────────────────────────
        var startStation = await _stationRepository.GetByIdAsync(startId)
            ?? throw new StationNotFoundException($"Station with ID {startId} was not found.");

        var endStation = await _stationRepository.GetByIdAsync(endId)
            ?? throw new StationNotFoundException($"Station with ID {endId} was not found.");

        // ── Route calculation (algorithm lives in IRouteService) ─────────────
        var stationIds = await _routeService.GetShortestPathAsync(startId, endId);

        if (stationIds is null || stationIds.Count == 0)
            throw new InvalidRouteException($"No route found between '{startStation.Name}' and '{endStation.Name}'.");

        // ── Resolve full station objects for the path ────────────────────────
        var stationsOnPath = new List<Entities.Station>();
        var stationNames = new List<string>();

        foreach (var id in stationIds)
        {
            var station = await _stationRepository.GetByIdAsync(id)
                ?? throw new StationNotFoundException($"Station with ID {id} on the calculated path was not found.");

            stationsOnPath.Add(station);
            stationNames.Add(station.Name);
        }

        // ── Station count ────────────────────────────────────────────────────
        // stationCount = number of stations traversed (including start & end)
        int stationCount = stationsOnPath.Count;

        // ── Delegate to specialist services (no logic inline) ────────────────
        int estimatedTime = _travelTimeService.CalculateTravelTime(stationCount);
        int transfers = _transferDetectionService.CountTransfers(stationsOnPath);

        var pricingRules = await _pricingRuleRepository.GetAllAsync();
        decimal price = _pricingService.CalculatePrice(stationCount, pricingRules);

        // ── Build and return DTO ─────────────────────────────────────────────
        return new RouteResultDto
        {
            FromStationName = startStation.Name,
            ToStationName = endStation.Name,
            Stations = stationNames,
            StationCount = stationCount,
            Transfers = transfers,
            Price = price,
            EstimatedTimeMinutes = estimatedTime,
        };
    }
}
