using JetBrains.Annotations;

namespace XW
{
	[PublicAPI]
	public interface IVersionInfo
	{
		string Comments { get; }
		string CompanyName { get; }
		string Language { get; }

		string FileName { get; }
		string FileDescription { get; }

		string ProductName { get; }
		string InternalName { get; }
		string OriginalFilename { get; }

		string FileVersion { get; }
		int FileMajorPart { get; }
		int FileMinorPart { get; }
		int FileRevisionPart { get; }
		int FileBuildPart { get; }
		int FilePrivatePart { get; }

		string ProductVersion { get; }
		int ProductMajorPart { get; }
		int ProductMinorPart { get; }
		int ProductRevisionPart { get; }
		int ProductBuildPart { get; }
		int ProductPrivatePart { get; }

		bool IsDebug { get; }
		bool IsPatched { get; }
		bool IsPrivateBuild { get; }
		bool IsPreRelease { get; }
		bool IsSpecialBuild { get; }

		string LegalCopyright { get; }
		string LegalTrademarks { get; }
		string SpecialBuild { get; }
	}
}