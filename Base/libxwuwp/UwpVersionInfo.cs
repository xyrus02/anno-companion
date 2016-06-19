using System;
using Windows.ApplicationModel;
using JetBrains.Annotations;

namespace XW
{
	[PublicAPI]
	public class UwpVersionInfo : IVersionInfo
	{
		private readonly Package mPackage;

		internal UwpVersionInfo(Package package)
		{
			mPackage = package;
		}

		public string Comments => mPackage?.Description;
		public string CompanyName => mPackage?.PublisherDisplayName;
		public string Language => null;

		public string FileName => mPackage?.Id?.Name;
		public string FileDescription => mPackage?.Id?.FullName;

		public string ProductName => mPackage?.DisplayName;
		public string InternalName => FileName;
		public string OriginalFilename => FileName;

		public string FileVersion => $"{FileMajorPart}.{FileMinorPart}.{FileRevisionPart}.{FileBuildPart}";
		public int FileMajorPart => PackageFileVersion?.Major ?? 0;
		public int FileMinorPart => PackageFileVersion?.Minor ?? 0;
		public int FileRevisionPart => PackageFileVersion?.Revision ?? 0;
		public int FileBuildPart => PackageFileVersion?.Build ?? 0;
		public int FilePrivatePart => 0;

		public string ProductVersion => $"{ProductMajorPart}.{ProductMinorPart}.{ProductRevisionPart}.{ProductBuildPart}";
		public int ProductMajorPart => PackageProductVersion?.Major ?? 0;
		public int ProductMinorPart => PackageProductVersion?.Minor ?? 0;
		public int ProductRevisionPart => PackageProductVersion?.Revision ?? 0;
		public int ProductBuildPart => PackageProductVersion?.Build ?? 0;
		public int ProductPrivatePart => 0;

		public bool IsDebug => mPackage?.IsDevelopmentMode ?? false;
		public bool IsPatched => false;
		public bool IsPrivateBuild => false;
		public bool IsPreRelease => false;
		public bool IsSpecialBuild => false;

		public string LegalCopyright => mPackage?.Id?.Publisher.TryTransform(x => $"Copyright (c) {DateTime.Now.Year} {x}");
		public string LegalTrademarks => null;
		public string SpecialBuild => null;

		private PackageVersion? PackageFileVersion => mPackage?.Id?.Version;
		private PackageVersion? PackageProductVersion => mPackage?.Id?.Version;
	}
}