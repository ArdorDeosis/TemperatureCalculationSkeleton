namespace LeonCalculation.CalculationModels.Thermal;

/// <summary>
/// The thermal model implemented as a stateless, static class (basically a function library). The configuration is
/// handed over in the function call. If there is a chance at some point in the future that this model needs to have
/// state, it should not be implemented with a static class anymore. One could think about implementing it as a
/// non-static class to be instantiated. See LossModel for more detail.
/// </summary>
public static class ThermalModel
{
  public static double CalculateTemperature(ThermalModelInput input, ThermalModelConfiguration configuration)
  {
    // do fancy shit
    return 0;
  }
}