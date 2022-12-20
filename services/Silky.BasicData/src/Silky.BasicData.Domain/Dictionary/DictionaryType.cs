using Silky.Hero.Common.EntityFrameworkCore.Entities;
using System.Collections.Generic;

namespace Silky.BasicData.Domain.Dictionary;

public class DictionaryType : FullAuditedEntity
{
    public string Name { get; set; }

    public string Code { get; set; }

    public int Sort { get; set; }

    public string Remark { get; set; }

    public virtual ICollection<DictionaryItem> DictionaryItems { get; set; }

}