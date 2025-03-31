﻿using HomeSecurity.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeSecurity.DAL.Data;

public static class ModelBuilderExtensions
{
    public static void SeedLocations(this ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Location>()
            .HasData(
                new Location { Id = 1, Name = "Головний вхід" },
                new Location { Id = 2, Name = "Вітальня" },
                new Location { Id = 3, Name = "Тамбур" },
                new Location { Id = 4, Name = "Задній вхід" },
                new Location { Id = 5, Name = "Підсобне приміщення" },
                new Location { Id = 6, Name = "Житлова кімната 1" },
                new Location { Id = 7, Name = "Житлова кімната 2" },
                new Location { Id = 8, Name = "Коридор" }
            );
    }

    public static void SeedSensors(this ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Sensor>()
            .HasData(
                // Головний вхід: Відеодзвінок (VideoDoorbell)
                new Sensor
                {
                    Id = 1,
                    Name = "Відеодзвінок - Головний вхід",
                    SensorType = SensorType.VideoDoorbell,
                    LocationId = 1,
                    DataLabel = "Рух",
                    Data = "no motion",
                    IsAlert = false,
                    LastReading = null
                },
                // Вітальня: 3 датчики розбиття скла (GlassBreak)
                new Sensor
                {
                    Id = 2,
                    Name = "Датчик розбиття скла 1 - Вітальня",
                    SensorType = SensorType.GlassBreak,
                    LocationId = 2,
                    DataLabel = "Рівень шуму",
                    Data = "0",
                    IsAlert = false,
                    LastReading = 0.0
                },
                new Sensor
                {
                    Id = 3,
                    Name = "Датчик розбиття скла 2 - Вітальня",
                    SensorType = SensorType.GlassBreak,
                    LocationId = 2,
                    DataLabel = "Рівень шуму",
                    Data = "0",
                    IsAlert = false,
                    LastReading = 0.0
                },
                new Sensor
                {
                    Id = 4,
                    Name = "Датчик розбиття скла 3 - Вітальня",
                    SensorType = SensorType.GlassBreak,
                    LocationId = 2,
                    DataLabel = "Рівень шуму",
                    Data = "0",
                    IsAlert = false,
                    LastReading = 0.0
                },
                // Вітальня: датчик руху (Motion)
                new Sensor
                {
                    Id = 5,
                    Name = "Датчик руху - Вітальня",
                    SensorType = SensorType.Motion,
                    LocationId = 2,
                    DataLabel = "Рух",
                    Data = "no motion",
                    IsAlert = false,
                    LastReading = null
                },
                // Тамбур: датчик відкриття дверей (Door)
                new Sensor
                {
                    Id = 6,
                    Name = "Датчик відкриття дверей - Тамбур",
                    SensorType = SensorType.Door,
                    LocationId = 3,
                    DataLabel = "Стан",
                    Data = "no motion",
                    IsAlert = false,
                    LastReading = null
                },
                // Тамбур: датчик руху (Motion)
                new Sensor
                {
                    Id = 7,
                    Name = "Датчик руху - Тамбур",
                    SensorType = SensorType.Motion,
                    LocationId = 3,
                    DataLabel = "Рух",
                    Data = "no motion",
                    IsAlert = false,
                    LastReading = null
                },
                // Задній вхід: датчик відкриття дверей (Door)
                new Sensor
                {
                    Id = 8,
                    Name = "Датчик відкриття дверей - Задній вхід",
                    SensorType = SensorType.Door,
                    LocationId = 4,
                    DataLabel = "Стан",
                    Data = "no motion",
                    IsAlert = false,
                    LastReading = null
                },
                // Підсобне приміщення: датчик відкриття дверей (Door)
                new Sensor
                {
                    Id = 9,
                    Name = "Датчик відкриття дверей - Підсобне приміщення",
                    SensorType = SensorType.Door,
                    LocationId = 5,
                    DataLabel = "Стан",
                    Data = "no motion",
                    IsAlert = false,
                    LastReading = null
                },
                // Житлова кімната 1: датчик розбиття скла (GlassBreak)
                new Sensor
                {
                    Id = 10,
                    Name = "Датчик розбиття скла - Житлова кімната 1",
                    SensorType = SensorType.GlassBreak,
                    LocationId = 6,
                    DataLabel = "Рівень шуму",
                    Data = "0",
                    IsAlert = false,
                    LastReading = 0.0
                },
                // Житлова кімната 2: датчик розбиття скла (GlassBreak)
                new Sensor
                {
                    Id = 11,
                    Name = "Датчик розбиття скла - Житлова кімната 2",
                    SensorType = SensorType.GlassBreak,
                    LocationId = 7,
                    DataLabel = "Рівень шуму",
                    Data = "0",
                    IsAlert = false,
                    LastReading = 0.0
                },
                // Коридор: датчик руху (Motion)
                new Sensor
                {
                    Id = 12,
                    Name = "Датчик руху - Коридор",
                    SensorType = SensorType.Motion,
                    LocationId = 8,
                    DataLabel = "Рух",
                    Data = "no motion",
                    IsAlert = false,
                    LastReading = null
                }
            );
    }
}