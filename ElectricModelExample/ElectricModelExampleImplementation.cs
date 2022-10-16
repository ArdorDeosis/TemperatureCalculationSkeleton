using LeonCalculation.CalculationModels.Electric;

namespace LeonCalculation.ElectricModelExample;

/// <summary>
/// Example implementation of an ElectricModel to showcase how specific configuration is handled.
/// </summary>
public sealed class ElectricModelExampleImplementation : ElectricModel
{
  private readonly ElectricModelExampleConfiguration configuration;
  
  /// <summary>
  /// Constructor receiving the configuration specifically for this model implementation.
  /// </summary>
  public ElectricModelExampleImplementation(ElectricModelExampleConfiguration configuration)
  {
    this.configuration = configuration;
  }

  /// <inheritdoc />
  public override ElectricModelOutput Calculate(Datapoint datapoint)
  {
    // do actual calculation using the specific configuration
    return new ElectricModelOutput();
  }
}