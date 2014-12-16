using System.Collections.Generic;
using ModuleManager.DomainDAL;

namespace ModuleManager.Web.Controllers.Api.Interfaces
{
    public interface ITagController
    {
        IEnumerable<Tag> GetAllTags();
        Tag GetTag(string naam);
        bool DeleteTag(Tag tag);
        bool EditTag(Tag tag);
        bool CreateTag(Tag tag);
    }
}