using NeuralNetworks.Exceptions;
using NeuralNetworks.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworks.Helpers
{
    public static class TrainingDataLoader
    {
        public static List<TrainingDataSet> GetData(string text)
        {
            var rows = text.Split("\n");

            var data = new List<TrainingDataSet>();

            for (int i = 0; i < rows.Length; i+=2)
            {
                var inputRow = rows[i];
                var outputRow = rows[i+1];

                var inputElements = inputRow.Split(";");
                var outputElements = outputRow.Split(";");

                List<double> output = new List<double>();
                List<double> input = new List<double>();

                foreach (var inputElement in inputElements)
                {
                    var value = double.Parse(inputElement.Replace('.', ',').Trim());
                    input.Add(value);
                }
                foreach (var outputElement in outputElements)
                {
                    var value = double.Parse(outputElement.Replace('.', ',').Trim());
                    output.Add(value);
                }
                data.Add(new TrainingDataSet(input.ToArray(), output.ToArray()));
            }

            return data;
        }
    }
}
