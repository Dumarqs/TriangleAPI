using Infra.CrossCutting.FileManager.Interfaces;
using Infra.CrossCutting.Logging;
using Infra.CrossCutting.Logging.Interfaces;
using Service.Extensions;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class TriangleService : ITriangleService
    {
        private readonly ILoggerAdapter<TriangleService> _logger;
        private readonly ILoadTextFile _loadTextFile;

        public TriangleService(ILoggerAdapter<TriangleService> logger, ILoadTextFile loadTextFile)
        {
            _logger = logger;
            _loadTextFile = loadTextFile;
        }
        public async Task<int> GetMaximumTotalFromTextFile()
        {
            var fileResult = await _loadTextFile.LoadFile();

            return await CalculateTotal(fileResult.ToListArrayInt());
        }

        private Task<int> CalculateTotal(List<int[]> listArray)
        {
            int arraySize = listArray.Count;
            for (int i = 0; i < (arraySize - 1); i++)
            {
                var lastArray = listArray.Last();
                var penultimeArray = listArray[^2];

                for (int j = 0; j < penultimeArray.Length; j++)
                {
                    penultimeArray[j] += lastArray[j] > lastArray[j + 1] ? lastArray[j] : lastArray[j + 1];
                }

                listArray.RemoveAt(listArray.Count - 1);
                listArray[^1] = penultimeArray;
            }

            _logger.LogInformation($"The total is {listArray.First()[0]}");
            return Task.FromResult(listArray.First()[0]);
        }
    }
}
