using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionCrafter.Specification.Utils
{
    public static class RepositoryUtils
    {
        public static string GenerateInternalRepositoryName(RepositoryPrivilegesType repositoryPrivileges, RepositoryOriginType repositoryOrigin, string repositoryName)
        {
            return GenerateInternalRepositoryName(repositoryPrivileges, repositoryOrigin, null, repositoryName);
        }

        public static string GenerateInternalRepositoryName(RepositoryPrivilegesType repositoryPrivileges, RepositoryOriginType repositoryOrigin, Type? repositoryEntityType, string? repositoryName = null)
        {
            List<string> names = new List<string>() { "Repository", "repository" };
            var builder = new StringBuilder();
            if (repositoryName == null && repositoryEntityType == null)
                throw new ArgumentNullException(nameof(repositoryEntityType));

            builder.Append(repositoryName ?? repositoryEntityType?.Name);
            foreach (var item in names)
            {
                if (builder.ToString().Contains(item))
                {
                    builder.Replace(item, null);
                    break;
                }
            }
            switch (repositoryPrivileges)
            {
                case RepositoryPrivilegesType.Write:
                    builder.Append("-Write");
                    break;

                case RepositoryPrivilegesType.Read:
                    builder.Append("-Read");
                    break;

                case RepositoryPrivilegesType.Complete:
                    builder.Append("-Complete");
                    break;

                default:
                    break;
            }
            builder.Append("Repository");
            switch (repositoryOrigin)
            {
                case RepositoryOriginType.Database:
                    builder.Append("-Database");
                    break;

                case RepositoryOriginType.File:
                    builder.Append("-File");
                    break;

                case RepositoryOriginType.Memory:
                    builder.Append("-Memory");
                    break;

                case RepositoryOriginType.Api:
                    builder.Append("-Api");
                    break;

                default:
                    break;
            }
            return builder.ToString();
        }
    }
}