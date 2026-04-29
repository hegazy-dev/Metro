DECLARE @json NVARCHAR(MAX) = N'
[
  {
    "Id": 1,
    "MinStations": 1,
    "MaxStations": 9,
    "Price": 8
  },
  {
    "Id": 2,
    "MinStations": 10,
    "MaxStations": 16,
    "Price": 10
  },
  {
    "Id": 3,
    "MinStations": 17,
    "MaxStations": 999,
    "Price": 15
  }
]';

INSERT INTO PricingRules (Id, MinStations, MaxStations, Price)
SELECT
    Id,
	MinStations,
	MaxStations,
	Price
FROM OPENJSON(@json)
WITH (
    Id INT,
    MinStations INT,
    MaxStations INT,
    Price Decimal
);