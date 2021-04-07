using System.Collections.Generic;

namespace Specification.Builder
{
    public class IncludeAggregator : IIncludeAggregator
    {
        private readonly List<string?> _naviagationPropertyNames = new List<string?>();
        public IncludeAggregator(string? navigationPropertyName)
        {
            AddNavigationPropertyName(navigationPropertyName);
        }

        public void AddNavigationPropertyName(string? navigationPropertyName)
        {
            if (!string.IsNullOrEmpty(navigationPropertyName))
            {
                _naviagationPropertyNames.Add(navigationPropertyName);
            }
        }

        public string? IncludeString
        {
            get
            {
                var output = string.Empty;
                for (var i = 0; i < _naviagationPropertyNames.Count; i++)
                {
                    output = i == 0 ? _naviagationPropertyNames[i] : $"{output}.{_naviagationPropertyNames[i]}";
                }

                return output;
            }

        }
    }
}