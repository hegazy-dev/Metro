using Metro.Core.Entities;
using Metro.Data.Seed.SeedModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Metro.Data.Seed;

public static class MetroDataSeeder
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public static async Task SeedAsync(
        MetroDbContext context,
        ILogger? logger = null,
        CancellationToken cancellationToken = default)
    {
        var basePath = Path.Combine(AppContext.BaseDirectory, "SeedData");

        var lines = await LoadAsync<List<LineSeedModel>>(
            Path.Combine(basePath, "lines.json"),
            cancellationToken);
        var stations = await LoadAsync<List<StationSeedModel>>(
            Path.Combine(basePath, "stations.json"),
            cancellationToken);
        var connections = await LoadAsync<List<ConnectionSeedModel>>(
            Path.Combine(basePath, "connections.json"),
            cancellationToken);
        var pricingRules = await LoadAsync<List<PricingRuleSeedModel>>(
            Path.Combine(basePath, "pricingRules.json"),
            cancellationToken);

        await TrySeedStepAsync(
            "Lines",
            () => SeedLinesAsync(context, lines, cancellationToken),
            logger);

        await TrySeedStepAsync(
            "Stations",
            () => SeedStationsAsync(context, stations, cancellationToken),
            logger);

        await TrySeedStepAsync(
            "StationConnections",
            () => SeedConnectionsAsync(context, connections, cancellationToken),
            logger);

        await TrySeedStepAsync(
            "PricingRules",
            () => SeedPricingRulesAsync(context, pricingRules, cancellationToken),
            logger);
    }

    private static async Task SeedLinesAsync(
        MetroDbContext context,
        IReadOnlyCollection<LineSeedModel> lines,
        CancellationToken cancellationToken)
    {
        var existingIds = (await context.Lines
    .Select(line => line.Id)
    .ToListAsync(cancellationToken)).ToHashSet();

        var newLines = lines
            .Where(line => line.Id > 0 && !existingIds.Contains(line.Id))
            .Select(line => new Line(line.Id, line.Name, line.Color))
            .ToList();

        if (newLines.Count == 0)
            return;

        await context.Lines.AddRangeAsync(newLines, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    private static async Task SeedStationsAsync(
        MetroDbContext context,
        IReadOnlyCollection<StationSeedModel> stations,
        CancellationToken cancellationToken)
    {
        var existingStationIds = (await context.Stations
            .Select(station => station.Id)
            .ToListAsync(cancellationToken)).ToHashSet();

        var existingLineIds = (await context.Lines
            .Select(line => line.Id)
            .ToListAsync(cancellationToken)).ToHashSet();

        var newStations = stations
            .Where(station => station.Id > 0)
            .Where(station => station.LineId > 0 && existingLineIds.Contains(station.LineId))
            .Where(station => !existingStationIds.Contains(station.Id))
            .Select(station => new Station(
                station.Id,
                station.Name,
                station.LineId,
                station.Latitude,
                station.Longitude,
                station.Order))
            .ToList();

        if (newStations.Count == 0)
            return;

        await context.Stations.AddRangeAsync(newStations, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    private static async Task SeedConnectionsAsync(
        MetroDbContext context,
        IReadOnlyCollection<ConnectionSeedModel> connections,
        CancellationToken cancellationToken)
    {
        var existingConnectionIds = (await context.StationConnections
            .Select(connection => connection.Id)
            .ToListAsync(cancellationToken)).ToHashSet();

        var existingStationIds = (await context.Stations
            .Select(station => station.Id)
            .ToListAsync(cancellationToken)).ToHashSet();

        var newConnections = connections
            .Where(connection => connection.Id > 0)
            .Where(connection => connection.FromStationId > 0 && connection.ToStationId > 0)
            .Where(connection =>
                existingStationIds.Contains(connection.FromStationId) &&
                existingStationIds.Contains(connection.ToStationId))
            .GroupBy(connection => connection.Id)
            .Select(group => group.First())
            .Where(connection => !existingConnectionIds.Contains(connection.Id))
            .Select(connection => new StationConnection(
                connection.Id,
                connection.FromStationId,
                connection.ToStationId))
            .ToList();

        if (newConnections.Count == 0)
            return;

        await context.StationConnections.AddRangeAsync(newConnections, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    private static async Task SeedPricingRulesAsync(
        MetroDbContext context,
        IReadOnlyCollection<PricingRuleSeedModel> pricingRules,
        CancellationToken cancellationToken)
    {
        var existingRuleIds = (await context.PricingRules
            .Select(rule => rule.Id)
            .ToListAsync(cancellationToken)).ToHashSet();

        var newRules = pricingRules
            .Where(rule => rule.Id > 0)
            .Where(rule => !existingRuleIds.Contains(rule.Id))
            .Select(rule => new PricingRule(
                rule.Id,
                rule.MinStations,
                rule.MaxStations,
                rule.Price))
            .ToList();

        if (newRules.Count == 0)
            return;

        await context.PricingRules.AddRangeAsync(newRules, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    private static async Task TrySeedStepAsync(
        string stepName,
        Func<Task> step,
        ILogger? logger)
    {
        try
        {
            await step();
        }
        catch (Exception ex)
        {
            logger?.LogError(ex, "Seed step '{SeedStep}' failed.", stepName);
        }
    }

    private static async Task<T> LoadAsync<T>(string path, CancellationToken cancellationToken)
    {
        var json = await File.ReadAllTextAsync(path, cancellationToken);
        var data = JsonSerializer.Deserialize<T>(json, JsonOptions);

        if (data is null)
            throw new InvalidOperationException($"Invalid seed file: {path}");

        return data;
    }
}
