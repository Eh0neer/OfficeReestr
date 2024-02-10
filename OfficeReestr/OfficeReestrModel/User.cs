using System;
using System.Collections.Generic;

namespace OfficeReestr.OfficeReestrModel;

public partial class User
{
    public int UserId { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }
    
    // Добавляем поле для хранения соли
    public string Salt { get; set; }

    public int? RoleId { get; set; }

    public virtual Role? Role { get; set; }
}
