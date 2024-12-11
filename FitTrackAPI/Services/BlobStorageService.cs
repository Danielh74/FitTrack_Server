using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace FitTrackAPI.Services;

public class BlobStorageService
{
	private readonly BlobServiceClient serviceClient;
	private readonly BlobContainerClient containerClient;
	public BlobStorageService(string connectionString)
	{
		serviceClient = new BlobServiceClient(connectionString);
		containerClient = serviceClient.GetBlobContainerClient("videos");
		containerClient.CreateIfNotExistsAsync();
		containerClient.SetAccessPolicy(PublicAccessType.Blob);
	}

	public async Task<string> UploadVideoAsync(Stream videoStream, string blobName, string contentType)
	{
		try
		{
			var blobClient = containerClient.GetBlobClient(blobName);

			await blobClient.UploadAsync(videoStream, overwrite: true);

			await blobClient.SetHttpHeadersAsync(new BlobHttpHeaders { ContentType = contentType });

			return blobClient.Uri.ToString();
		}
		catch (Exception)
		{
			return "";
		}
	}

	public async Task<bool> DeleteVideoAsync(string blobName)
	{
		var blobClient = containerClient.GetBlobClient(blobName);

		return await blobClient.DeleteIfExistsAsync(DeleteSnapshotsOption.IncludeSnapshots);
	}
}
