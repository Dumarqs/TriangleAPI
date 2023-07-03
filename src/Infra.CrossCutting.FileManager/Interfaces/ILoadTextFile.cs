namespace Infra.CrossCutting.FileManager.Interfaces
{
    /// <summary>
    /// Load the txt file from the system
    /// </summary>
    public interface ILoadTextFile
    {
        /// <summary>
        /// Load File
        /// </summary>
        /// <returns>List<string></returns>
        Task<List<string>> LoadFile();
    }
}
