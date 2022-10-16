namespace LeonCalculation.CalculationModels.Electric;

/// <summary>
/// An abstract class for an electric model to be implemented by other devs.
/// </summary>
public abstract class ElectricModel
{
  /// <summary>
  /// Calculates the ??? (I really don't know what) for the given datapoint.
  /// </summary>
  public abstract ElectricModelOutput Calculate(Datapoint datapoint);
}