DECLARE @json NVARCHAR(MAX) = N'
[
  {
    "id": 1,
    "fromStationId": 1,
    "toStationId": 2
  },
  {
    "id": 2,
    "fromStationId": 2,
    "toStationId": 1
  },
  {
    "id": 3,
    "fromStationId": 2,
    "toStationId": 3
  },
  {
    "id": 4,
    "fromStationId": 3,
    "toStationId": 2
  },
  {
    "id": 5,
    "fromStationId": 3,
    "toStationId": 4
  },
  {
    "id": 6,
    "fromStationId": 4,
    "toStationId": 3
  },
  {
    "id": 7,
    "fromStationId": 4,
    "toStationId": 5
  },
  {
    "id": 8,
    "fromStationId": 5,
    "toStationId": 4
  },
  {
    "id": 9,
    "fromStationId": 5,
    "toStationId": 6
  },
  {
    "id": 10,
    "fromStationId": 6,
    "toStationId": 5
  },
  {
    "id": 11,
    "fromStationId": 6,
    "toStationId": 7
  },
  {
    "id": 12,
    "fromStationId": 7,
    "toStationId": 6
  },
  {
    "id": 13,
    "fromStationId": 7,
    "toStationId": 8
  },
  {
    "id": 14,
    "fromStationId": 8,
    "toStationId": 7
  },
  {
    "id": 15,
    "fromStationId": 8,
    "toStationId": 9
  },
  {
    "id": 16,
    "fromStationId": 9,
    "toStationId": 8
  },
  {
    "id": 17,
    "fromStationId": 9,
    "toStationId": 10
  },
  {
    "id": 18,
    "fromStationId": 10,
    "toStationId": 9
  },
  {
    "id": 19,
    "fromStationId": 10,
    "toStationId": 11
  },
  {
    "id": 20,
    "fromStationId": 11,
    "toStationId": 10
  },
  {
    "id": 21,
    "fromStationId": 11,
    "toStationId": 12
  },
  {
    "id": 22,
    "fromStationId": 12,
    "toStationId": 11
  },
  {
    "id": 23,
    "fromStationId": 12,
    "toStationId": 13
  },
  {
    "id": 24,
    "fromStationId": 13,
    "toStationId": 12
  },
  {
    "id": 25,
    "fromStationId": 13,
    "toStationId": 14
  },
  {
    "id": 26,
    "fromStationId": 14,
    "toStationId": 13
  },
  {
    "id": 27,
    "fromStationId": 14,
    "toStationId": 15
  },
  {
    "id": 28,
    "fromStationId": 15,
    "toStationId": 14
  },
  {
    "id": 29,
    "fromStationId": 15,
    "toStationId": 16
  },
  {
    "id": 30,
    "fromStationId": 16,
    "toStationId": 15
  },
  {
    "id": 31,
    "fromStationId": 16,
    "toStationId": 17
  },
  {
    "id": 32,
    "fromStationId": 17,
    "toStationId": 16
  },
  {
    "id": 33,
    "fromStationId": 17,
    "toStationId": 18
  },
  {
    "id": 34,
    "fromStationId": 18,
    "toStationId": 17
  },
  {
    "id": 35,
    "fromStationId": 18,
    "toStationId": 19
  },
  {
    "id": 36,
    "fromStationId": 19,
    "toStationId": 18
  },
  {
    "id": 37,
    "fromStationId": 19,
    "toStationId": 20
  },
  {
    "id": 38,
    "fromStationId": 20,
    "toStationId": 19
  },
  {
    "id": 39,
    "fromStationId": 20,
    "toStationId": 21
  },
  {
    "id": 40,
    "fromStationId": 21,
    "toStationId": 20
  },
  {
    "id": 41,
    "fromStationId": 21,
    "toStationId": 22
  },
  {
    "id": 42,
    "fromStationId": 22,
    "toStationId": 21
  },
  {
    "id": 43,
    "fromStationId": 22,
    "toStationId": 23
  },
  {
    "id": 44,
    "fromStationId": 23,
    "toStationId": 22
  },
  {
    "id": 45,
    "fromStationId": 23,
    "toStationId": 24
  },
  {
    "id": 46,
    "fromStationId": 24,
    "toStationId": 23
  },
  {
    "id": 47,
    "fromStationId": 24,
    "toStationId": 25
  },
  {
    "id": 48,
    "fromStationId": 25,
    "toStationId": 24
  },
  {
    "id": 49,
    "fromStationId": 25,
    "toStationId": 26
  },
  {
    "id": 50,
    "fromStationId": 26,
    "toStationId": 25
  },
  {
    "id": 51,
    "fromStationId": 26,
    "toStationId": 27
  },
  {
    "id": 52,
    "fromStationId": 27,
    "toStationId": 26
  },
  {
    "id": 53,
    "fromStationId": 27,
    "toStationId": 28
  },
  {
    "id": 54,
    "fromStationId": 28,
    "toStationId": 27
  },
  {
    "id": 55,
    "fromStationId": 28,
    "toStationId": 29
  },
  {
    "id": 56,
    "fromStationId": 29,
    "toStationId": 28
  },
  {
    "id": 57,
    "fromStationId": 29,
    "toStationId": 30
  },
  {
    "id": 58,
    "fromStationId": 30,
    "toStationId": 29
  },
  {
    "id": 59,
    "fromStationId": 30,
    "toStationId": 31
  },
  {
    "id": 60,
    "fromStationId": 31,
    "toStationId": 30
  },
  {
    "id": 61,
    "fromStationId": 31,
    "toStationId": 32
  },
  {
    "id": 62,
    "fromStationId": 32,
    "toStationId": 31
  },
  {
    "id": 63,
    "fromStationId": 32,
    "toStationId": 33
  },
  {
    "id": 64,
    "fromStationId": 33,
    "toStationId": 32
  },
  {
    "id": 65,
    "fromStationId": 33,
    "toStationId": 34
  },
  {
    "id": 66,
    "fromStationId": 34,
    "toStationId": 33
  },
  {
    "id": 67,
    "fromStationId": 34,
    "toStationId": 35
  },
  {
    "id": 68,
    "fromStationId": 35,
    "toStationId": 34
  },
  {
    "id": 69,
    "fromStationId": 36,
    "toStationId": 37
  },
  {
    "id": 70,
    "fromStationId": 37,
    "toStationId": 36
  },
  {
    "id": 71,
    "fromStationId": 37,
    "toStationId": 38
  },
  {
    "id": 72,
    "fromStationId": 38,
    "toStationId": 37
  },
  {
    "id": 73,
    "fromStationId": 38,
    "toStationId": 39
  },
  {
    "id": 74,
    "fromStationId": 39,
    "toStationId": 38
  },
  {
    "id": 75,
    "fromStationId": 39,
    "toStationId": 40
  },
  {
    "id": 76,
    "fromStationId": 40,
    "toStationId": 39
  },
  {
    "id": 77,
    "fromStationId": 40,
    "toStationId": 41
  },
  {
    "id": 78,
    "fromStationId": 41,
    "toStationId": 40
  },
  {
    "id": 79,
    "fromStationId": 41,
    "toStationId": 42
  },
  {
    "id": 80,
    "fromStationId": 42,
    "toStationId": 41
  },
  {
    "id": 81,
    "fromStationId": 42,
    "toStationId": 43
  },
  {
    "id": 82,
    "fromStationId": 43,
    "toStationId": 42
  },
  {
    "id": 83,
    "fromStationId": 43,
    "toStationId": 44
  },
  {
    "id": 84,
    "fromStationId": 44,
    "toStationId": 43
  },
  {
    "id": 85,
    "fromStationId": 44,
    "toStationId": 45
  },
  {
    "id": 86,
    "fromStationId": 45,
    "toStationId": 44
  },
  {
    "id": 87,
    "fromStationId": 45,
    "toStationId": 46
  },
  {
    "id": 88,
    "fromStationId": 46,
    "toStationId": 45
  },
  {
    "id": 89,
    "fromStationId": 46,
    "toStationId": 47
  },
  {
    "id": 90,
    "fromStationId": 47,
    "toStationId": 46
  },
  {
    "id": 91,
    "fromStationId": 47,
    "toStationId": 48
  },
  {
    "id": 92,
    "fromStationId": 48,
    "toStationId": 47
  },
  {
    "id": 93,
    "fromStationId": 48,
    "toStationId": 49
  },
  {
    "id": 94,
    "fromStationId": 49,
    "toStationId": 48
  },
  {
    "id": 95,
    "fromStationId": 49,
    "toStationId": 50
  },
  {
    "id": 96,
    "fromStationId": 50,
    "toStationId": 49
  },
  {
    "id": 97,
    "fromStationId": 50,
    "toStationId": 51
  },
  {
    "id": 98,
    "fromStationId": 51,
    "toStationId": 50
  },
  {
    "id": 99,
    "fromStationId": 51,
    "toStationId": 52
  },
  {
    "id": 100,
    "fromStationId": 52,
    "toStationId": 51
  },
  {
    "id": 101,
    "fromStationId": 52,
    "toStationId": 53
  },
  {
    "id": 102,
    "fromStationId": 53,
    "toStationId": 52
  },
  {
    "id": 103,
    "fromStationId": 53,
    "toStationId": 54
  },
  {
    "id": 104,
    "fromStationId": 54,
    "toStationId": 53
  },
  {
    "id": 105,
    "fromStationId": 54,
    "toStationId": 55
  },
  {
    "id": 106,
    "fromStationId": 55,
    "toStationId": 54
  },
  {
    "id": 107,
    "fromStationId": 56,
    "toStationId": 57
  },
  {
    "id": 108,
    "fromStationId": 57,
    "toStationId": 56
  },
  {
    "id": 109,
    "fromStationId": 57,
    "toStationId": 58
  },
  {
    "id": 110,
    "fromStationId": 58,
    "toStationId": 57
  },
  {
    "id": 111,
    "fromStationId": 58,
    "toStationId": 59
  },
  {
    "id": 112,
    "fromStationId": 59,
    "toStationId": 58
  },
  {
    "id": 113,
    "fromStationId": 59,
    "toStationId": 60
  },
  {
    "id": 114,
    "fromStationId": 60,
    "toStationId": 59
  },
  {
    "id": 115,
    "fromStationId": 60,
    "toStationId": 61
  },
  {
    "id": 116,
    "fromStationId": 61,
    "toStationId": 60
  },
  {
    "id": 117,
    "fromStationId": 61,
    "toStationId": 62
  },
  {
    "id": 118,
    "fromStationId": 62,
    "toStationId": 61
  },
  {
    "id": 119,
    "fromStationId": 62,
    "toStationId": 63
  },
  {
    "id": 120,
    "fromStationId": 63,
    "toStationId": 62
  },
  {
    "id": 121,
    "fromStationId": 63,
    "toStationId": 64
  },
  {
    "id": 122,
    "fromStationId": 64,
    "toStationId": 63
  },
  {
    "id": 123,
    "fromStationId": 64,
    "toStationId": 65
  },
  {
    "id": 124,
    "fromStationId": 65,
    "toStationId": 64
  },
  {
    "id": 125,
    "fromStationId": 65,
    "toStationId": 66
  },
  {
    "id": 126,
    "fromStationId": 66,
    "toStationId": 65
  },
  {
    "id": 127,
    "fromStationId": 66,
    "toStationId": 67
  },
  {
    "id": 128,
    "fromStationId": 67,
    "toStationId": 66
  },
  {
    "id": 129,
    "fromStationId": 67,
    "toStationId": 68
  },
  {
    "id": 130,
    "fromStationId": 68,
    "toStationId": 67
  },
  {
    "id": 131,
    "fromStationId": 68,
    "toStationId": 69
  },
  {
    "id": 132,
    "fromStationId": 69,
    "toStationId": 68
  },
  {
    "id": 133,
    "fromStationId": 69,
    "toStationId": 70
  },
  {
    "id": 134,
    "fromStationId": 70,
    "toStationId": 69
  },
  {
    "id": 135,
    "fromStationId": 70,
    "toStationId": 71
  },
  {
    "id": 136,
    "fromStationId": 71,
    "toStationId": 70
  },
  {
    "id": 137,
    "fromStationId": 71,
    "toStationId": 72
  },
  {
    "id": 138,
    "fromStationId": 72,
    "toStationId": 71
  },
  {
    "id": 139,
    "fromStationId": 72,
    "toStationId": 73
  },
  {
    "id": 140,
    "fromStationId": 73,
    "toStationId": 72
  },
  {
    "id": 141,
    "fromStationId": 73,
    "toStationId": 74
  },
  {
    "id": 142,
    "fromStationId": 74,
    "toStationId": 73
  },
  {
    "id": 143,
    "fromStationId": 74,
    "toStationId": 75
  },
  {
    "id": 144,
    "fromStationId": 75,
    "toStationId": 74
  },
  {
    "id": 145,
    "fromStationId": 75,
    "toStationId": 76
  },
  {
    "id": 146,
    "fromStationId": 76,
    "toStationId": 75
  },
  {
    "id": 147,
    "fromStationId": 76,
    "toStationId": 77
  },
  {
    "id": 148,
    "fromStationId": 77,
    "toStationId": 76
  },
  {
    "id": 149,
    "fromStationId": 77,
    "toStationId": 78
  },
  {
    "id": 150,
    "fromStationId": 78,
    "toStationId": 77
  },
  {
    "id": 151,
    "fromStationId": 78,
    "toStationId": 79
  },
  {
    "id": 152,
    "fromStationId": 79,
    "toStationId": 78
  },
  {
    "id": 153,
    "fromStationId": 79,
    "toStationId": 80
  },
  {
    "id": 154,
    "fromStationId": 80,
    "toStationId": 79
  },
  {
    "id": 155,
    "fromStationId": 80,
    "toStationId": 81
  },
  {
    "id": 156,
    "fromStationId": 81,
    "toStationId": 80
  },
  {
    "id": 157,
    "fromStationId": 81,
    "toStationId": 82
  },
  {
    "id": 158,
    "fromStationId": 82,
    "toStationId": 81
  },
  {
    "id": 159,
    "fromStationId": 82,
    "toStationId": 83
  },
  {
    "id": 160,
    "fromStationId": 83,
    "toStationId": 82
  },
  {
    "id": 161,
    "fromStationId": 83,
    "toStationId": 84
  },
  {
    "id": 162,
    "fromStationId": 84,
    "toStationId": 83
  },
  {
    "id": 163,
    "fromStationId": 84,
    "toStationId": 85
  },
  {
    "id": 164,
    "fromStationId": 85,
    "toStationId": 84
  },
  {
    "id": 165,
    "fromStationId": 85,
    "toStationId": 86
  },
  {
    "id": 166,
    "fromStationId": 86,
    "toStationId": 85
  },
  {
    "id": 167,
    "fromStationId": 86,
    "toStationId": 87
  },
  {
    "id": 168,
    "fromStationId": 87,
    "toStationId": 86
  },
  {
    "id": 169,
    "fromStationId": 87,
    "toStationId": 88
  },
  {
    "id": 170,
    "fromStationId": 88,
    "toStationId": 87
  },
  {
    "id": 171,
    "fromStationId": 88,
    "toStationId": 89
  },
  {
    "id": 172,
    "fromStationId": 89,
    "toStationId": 88
  },
  {
    "id": 173,
    "fromStationId": 19,
    "toStationId": 46
  },
  {
    "id": 174,
    "fromStationId": 46,
    "toStationId": 19
  },
  {
    "id": 175,
    "fromStationId": 22,
    "toStationId": 43
  },
  {
    "id": 176,
    "fromStationId": 43,
    "toStationId": 22
  },
  {
    "id": 177,
    "fromStationId": 44,
    "toStationId": 74
  },
  {
    "id": 178,
    "fromStationId": 74,
    "toStationId": 44
  },
  {
    "id": 179,
    "fromStationId": 20,
    "toStationId": 75
  },
  {
    "id": 180,
    "fromStationId": 75,
    "toStationId": 20
  },
  {
    "id": 181,
    "fromStationId": 50,
    "toStationId": 89
  },
  {
    "id": 182,
    "fromStationId": 89,
    "toStationId": 50
  }
]';

INSERT INTO StationConnections (Id, FromStationId, ToStationId)
SELECT
    Id,
    FromStationId,
    ToStationId
FROM OPENJSON(@json)
WITH (
    Id INT '$.id',
    FromStationId INT '$.fromStationId',
    ToStationId INT '$.toStationId'
);