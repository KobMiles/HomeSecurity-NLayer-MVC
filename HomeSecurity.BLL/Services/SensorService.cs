﻿using AutoMapper;
using HomeSecurity.BLL.DTOs.SensorAlerts;
using HomeSecurity.BLL.DTOs.Sensors;
using HomeSecurity.BLL.Interfaces.Services;
using HomeSecurity.DAL.Entities.Enums;
using HomeSecurity.DAL.Entities;
using HomeSecurity.DAL.Entities.Specifications.Sensors;
using HomeSecurity.DAL.Interfaces.Repositories;

namespace HomeSecurity.BLL.Services;

public class SensorService(IUnitOfWork unitOfWork, IAlarmService alarmService, IMapper mapper) : ISensorService
{
    private readonly Random _random = new();

    public async Task<IEnumerable<SensorDto>> GetAllSensorsAsync()
    {
        var spec = new SensorsWithLocationSpec();
        var sensors = await unitOfWork.Sensors.ListAsync(spec);
        return mapper.Map<IEnumerable<SensorDto>>(sensors);
    }

    public async Task<IEnumerable<SensorDto>> UpdateSensorsRandomlyAsync()
    {
        var spec = new SensorsWithLocationSpec();
        var sensors = await unitOfWork.Sensors.ListAsync(spec);

        var isAlarmActive = await alarmService.GetAlarmStatusAsync();
        foreach (var sensor in sensors)
        {
            switch (sensor.SensorType)
            {
                case SensorType.GlassBreak:
                    int noise = _random.Next(0, 101);
                    sensor.LastReading = noise;
                    sensor.Data = noise.ToString();
                    if (noise > 90)
                    {
                        sensor.IsAlert = isAlarmActive;
                        await CreateAlertForSensor(sensor, $"Сильний шум: {noise} dB");
                    }
                    else
                    {
                        sensor.IsAlert = false;
                    }
                    break;

                case SensorType.Door:
                    {
                        bool triggered = (_random.Next(1, 19) == 1);
                        if (triggered)
                        {
                            sensor.Data = "Рух виявлено";
                            sensor.IsAlert = isAlarmActive;
                            await CreateAlertForSensor(sensor, "Двері відкрились!");
                        }
                        else
                        {
                            sensor.Data = "Руху не виявлено";
                            sensor.IsAlert = false;
                        }
                        break;
                    }

                case SensorType.Motion:
                    {
                        bool triggered = (_random.Next(1, 19) == 1);
                        if (triggered)
                        {
                            sensor.Data = "Рух виявлено";
                            sensor.IsAlert = isAlarmActive;
                            await CreateAlertForSensor(sensor, "Рух виявлено!");
                        }
                        else
                        {
                            sensor.Data = "Руху не виявлено";
                            sensor.IsAlert = false;
                        }
                        break;
                    }

                case SensorType.VideoDoorbell:
                    {
                        bool triggered = (_random.Next(1, 19) == 1);
                        if (triggered)
                        {
                            sensor.Data = "Рух виявлено";
                            sensor.IsAlert = isAlarmActive;
                            await CreateAlertForSensor(sensor, "Відеодзвінок: рух!");
                        }
                        else
                        {
                            sensor.Data = "Руху не виявлено";
                            sensor.IsAlert = false;
                        }
                        break;
                    }
            }

            await unitOfWork.Sensors.UpdateAsync(sensor);
        }

        await unitOfWork.SaveAsync();
        return mapper.Map<IEnumerable<SensorDto>>(sensors);
    }

    public async Task CreateSensorAlertAsync(SensorAlertCreateDto sensorAlertDto)
    {
        var alert = mapper.Map<SensorAlert>(sensorAlertDto);
        alert.Timestamp = DateTime.Now;
        await unitOfWork.SensorAlerts.AddAsync(alert);
        await unitOfWork.SaveAsync();
    }

    private async Task CreateAlertForSensor(Sensor sensor, string message)
    {
        var isAlarmActive = await alarmService.GetAlarmStatusAsync();
        if (!isAlarmActive) 
            return;

        var alert = new SensorAlert
        {
            SensorId = sensor.Id,
            Timestamp = DateTime.Now,
            Message = message
        };

        await unitOfWork.SensorAlerts.AddAsync(alert);
    }
}