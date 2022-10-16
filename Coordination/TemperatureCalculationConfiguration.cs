using LeonCalculation.CalculationModels.Electric;
using LeonCalculation.CalculationModels.Loss;
using LeonCalculation.CalculationModels.Thermal;

namespace LeonCalculation.Coordination;

/// <summary>
/// Configuration for a temperature calculation.
/// Electric-, Loss- and ThermalModel are implemented in three different ways to showcase all of them. While I think for
/// the electric model the given case is the only possible, the other two models could follow any of the three
/// implementations. In a 'real' solution I'd use the same pattern for both of these, since their roles in the
/// calculation are quite similar.
/// In the ElectricModel case, the configuration holds its own instance of an ElectricModel (abstract). The instance is
/// created by the user (dev) and handed over to this configuration. The reference is also only of the abstract type, to
/// make this configuration agnostic of the actual implementation. This decouples the two modules (electric model and
/// calculation coordination) and makes it easier for the future to change the electric model or have multiple
/// implementations in parallel - at the cost of slightly more complicated code. The same pattern could be used for the
/// other two models with the same reasoning: makes it easier in the future to switch out or have multiple
/// implementations of these models.  
/// In the other two cases, the model types are completely hidden from the user and the user only hands over a
/// configuration for each model. This makes the code simpler, since the user does not have to create a loss- or thermal
/// model instance, but it links the modules fairly rigidly together: The temperature calculation can only be done
/// with this one loss and this one thermal model. They are implemented in different ways, see their respective
/// documentations for details.
/// </summary>
public class TemperatureCalculationConfiguration
{
  /// <summary>
  /// Initial temperature for the first iteration. note: it might be a good idea to specify the temperature unit in the
  /// variable name (e.g. InitialTemperatureInKelvin).
  /// </summary>
  public readonly double InitialTemperature;
  
  /// <summary>
  /// The maximum difference in temperature between the output of the thermal model can have compared to the input of
  /// the loss model to accept the result.
  /// </summary>
  public readonly double RequiredAccuracy;
  
  /// <summary>
  /// Maximum number of iterations to be done. This is a failsafe, to prevent endless loops in case of erroneous
  /// calculation models that cannot converge.
  /// </summary>
  public readonly int MaxIterations;
  
  /// <summary>
  /// The electric model implementation to be used.
  /// </summary>
  public readonly ElectricModel ElectricModel;
  
  /// <summary>
  /// The configuration of the loss model.
  /// </summary>
  public readonly LossModelConfiguration LossModelConfiguration;
  
  /// <summary>
  /// The configuration of the thermal model.
  /// </summary>
  public readonly ThermalModelConfiguration ThermalModelConfiguration;

  public TemperatureCalculationConfiguration(
    double initialTemperature,
    double requiredAccuracy, 
    int maxIterations,
    ElectricModel electricModel, 
    LossModelConfiguration lossModelConfiguration, 
    ThermalModelConfiguration thermalModelConfiguration)
  {
    InitialTemperature = initialTemperature;
    RequiredAccuracy = requiredAccuracy;
    MaxIterations = maxIterations;
    ElectricModel = electricModel;
    LossModelConfiguration = lossModelConfiguration;
    ThermalModelConfiguration = thermalModelConfiguration;
  }
}