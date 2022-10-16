using System;
using LeonCalculation.CalculationModels.Electric;
using LeonCalculation.CalculationModels.Loss;
using LeonCalculation.CalculationModels.Thermal;
using Convert = LeonCalculation.DataConversion.Convert;

namespace LeonCalculation.Coordination;

/// <summary>
/// Temperature calculation class, instantiated with a configuration struct containing all necessary configuration.
/// </summary>
public sealed class TemperatureCalculator
{
  /// <summary>
  /// Configuration of this instance.
  /// </summary>
  /// <remarks>
  /// Readonly fields can only be set in the constructor, this ensures that it is not changed afterwards.
  /// </remarks>
  private readonly TemperatureCalculationConfiguration configuration;

  /// <summary>
  /// The loss model instance to be used by this calculation. See documentation of TemperatureCalculationConfiguration
  /// for more detail.
  /// </summary>
  private readonly LossModel lossModel;

  /// <summary>
  /// Constructor receiving a configuration.
  /// </summary>
  public TemperatureCalculator(TemperatureCalculationConfiguration configuration)
  {
    this.configuration = configuration;
    lossModel = new LossModel(configuration.LossModelConfiguration);
  }

  /// <summary>
  /// Calculates/simulates the model iteratively for the provided datapoint according to the configuration until a
  /// satisfying result is found.
  /// </summary>
  public double CalculateTemperature(Datapoint datapoint)
  {
    var electricOutput = configuration.ElectricModel.Calculate(datapoint);
    var lossInput = Convert.ElectricOutputToLossInput(electricOutput);

    var intermediateResult = configuration.InitialTemperature;
    // The iteration counter could be removed and instead a while(true) loop be used, but this seems cleaner to me,
    // preventing endless loops if the models are broken somehow and the iteration never converges. 
    var iterationsCounter = 0;
    while (iterationsCounter++ < configuration.MaxIterations)
    {
      var lossOutput = lossModel.Calculate(lossInput, intermediateResult);
      var thermalInput = Convert.LossOutputToThermalInput(lossOutput);
      var calculatedTemperature = ThermalModel.CalculateTemperature(thermalInput, configuration.ThermalModelConfiguration);
    
      if (Math.Abs(intermediateResult - calculatedTemperature) < configuration.RequiredAccuracy)
        return calculatedTemperature;

      intermediateResult = calculatedTemperature;
    }

    throw new Exception("Model could not find accurate result!");
  }
}