using BusinessLogic.Parsers;
using Microsoft.AspNetCore.Http;
using System.Text;
using Xunit;

namespace BusinessLogic.Tests.Parsers
{
	public class FileParserTests
	{
		private readonly FileParser _parser; 
		public FileParserTests()
		{
			_parser = new FileParser(); 
		}
		[Fact]
		public async Task ParseCsvAsync_WithValidData_ReturnsRows()
		{
			// Arrange
			var csvContent = "Date;ExecutionTime;Value\n" +
							"2023-03-12T15-30-23.1256Z;14;5.1\n" +
							"2022-04-11T12-33-11.1256Z;16;1.1\n";
			var file = CreateMockFile(csvContent);
			// Act
			var result = await _parser.ParseCsvAsync(file);
			// Assert
			Assert.Equal(2, result.Count);
			Assert.Equal(14, result[0].ExecutionTime);
			Assert.Equal(5.1, result[0].Value);
		}
		[Fact]
		public async Task ParseCsvAsync_WithInvalidColumnCount_ThrowsException()
		{
			// Arrange
			var csvContent = "Date;ExecutionTime;Value\n" +
							"2023-03-12T15-30-23.1256Z;14\n";
			var file = CreateMockFile(csvContent);
			// Act, Assert
			await Assert.ThrowsAsync<Exception>(() => _parser.ParseCsvAsync(file));
		}
		private IFormFile CreateMockFile(string content)
		{
			var bytes = Encoding.UTF8.GetBytes(content);
			var stream = new MemoryStream(bytes);
			stream.Position = 0; 
			var file = new FormFile(stream, 0, bytes.Length, "data", "test.csv")
			{
				Headers = new HeaderDictionary(),
				ContentType = "text/csv"
			};
			return file; 
		}
	}
}
