using System.Collections.Generic;

namespace ModuleManager.DomainDAL.RepositoryInterfaces
{
    public interface ITagRepository
    {
        IEnumerable<Tag> GetAllTags();
        Tag GetTag(string naam);
        bool CreateTag(Tag tag);
        bool DeleteTag(Tag tag);
        bool EditTag(Tag tag);
    }
}