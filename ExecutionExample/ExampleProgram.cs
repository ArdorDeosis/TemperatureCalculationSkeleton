using LeonCalculation.CalculationModels.Electric;
using LeonCalculation.CalculationModels.Thermal;
using LeonCalculation.Coordination;
using LeonCalculation.DataConversion;
using LeonCalculation.ElectricModelExample;

namespace LeonCalculation.ExecutionExample;

/// <summary>
/// An example of how the model is to be used.
/// </summary>
public static class ExampleProgram
{
  public static void Main()
  {
    // these are example datapoints to be calculated; assume the array to be filled
    var datapoints = new Datapoint[10000];
    
    // create electric model
    var electricModelConfiguration = new ElectricModelExampleConfiguration();
    var electricModel = new ElectricModelExampleImplementation(electricModelConfiguration);

    // parse loss model configuration file
    var xmlParser = new XmlLossModelConfigurationParser();
    var lossModelConfiguration = xmlParser.Parse("path/to/file/with/configuration.xml");
    
    // create thermal model configuration
    var thermalModelConfiguration = new ThermalModelConfiguration();
    
    // create calculation coordinator
    var configuration = new TemperatureCalculationConfiguration(
      25,
      .1,
      10000,
      electricModel,
      lossModelConfiguration,
      thermalModelConfiguration);
    var calculator = new TemperatureCalculator(configuration);
    
    // calculate
    foreach (var datapoint in datapoints)
    {
      var result = calculator.CalculateTemperature(datapoint);
      // do stuff with result
    }
  }
}