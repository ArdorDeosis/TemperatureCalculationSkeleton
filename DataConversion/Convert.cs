using LeonCalculation.CalculationModels.Electric;
using LeonCalculation.CalculationModels.Loss;
using LeonCalculation.CalculationModels.Thermal;

namespace LeonCalculation.DataConversion;

/// <summary>
/// Conversion helper functions.
/// </summary>
public static class Convert
{
  /// <summary>
  /// Converts electric model output to loss model input.
  /// </summary>
  public static LossModelInput ElectricOutputToLossInput(ElectricModelOutput electricModelOutput)
  {
    // do actual conversion
    return new LossModelInput();
  }
  
  /// <summary>
  /// Converts loss model output to thermal model input.
  /// </summary>
  public static ThermalModelInput LossOutputToThermalInput(LossModelOutput lossModelOutput)
  {
    // do actual conversion
    return new ThermalModelInput();
  }
}