namespace LeonCalculation.CalculationModels.Loss;

/// <summary>
/// The loss model implemented as a class. The configuration is handed over in the constructor and is used for all
/// calculations made with the respective instance. Since the LossModel has no other state than the configuration, one
/// could think about implementing it completely stateless (as static class). See ThermalModel for more detail.
/// </summary>
public sealed class LossModel
{
  private readonly LossModelConfiguration configuration;

  public LossModel(LossModelConfiguration configuration)
  {
    this.configuration = configuration;
  }

  public LossModelOutput Calculate(LossModelInput input, double temperature)
  {
    // do fancy shit
    return new LossModelOutput();
  }
}