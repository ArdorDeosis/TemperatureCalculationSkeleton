using LeonCalculation.CalculationModels.Loss;

namespace LeonCalculation.DataConversion;

/// <summary>
/// Interface for a loss model configuration parser. This one expects a filepath string as input. If there is the need
/// for other types of input (e.g. binary data), this approach might not work. 
/// </summary>
public abstract class LossModelConfigurationParser
{
  /// <summary>
  /// Parses the input file into a configuration usable by the loss model.
  /// </summary>
  public abstract LossModelConfiguration Parse(string filepath);
}