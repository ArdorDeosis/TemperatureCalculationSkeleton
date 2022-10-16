using LeonCalculation.CalculationModels.Loss;

namespace LeonCalculation.DataConversion;

/// <summary>
/// Loss model configuration parser for XML files.
/// </summary>
public class XmlLossModelConfigurationParser : LossModelConfigurationParser
{
  /// <inheritdoc />
  public override LossModelConfiguration Parse(string filename)
  {
    // do actual parsing
    return new LossModelConfiguration();
  }
}