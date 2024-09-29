using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class EmailQueue
{
    public int Id { get; set; }

    public string Recipients { get; set; }

    public string CcRecipients { get; set; }

    public string EmailSubject { get; set; }

    public string EmailBody { get; set; }

    public DateTime QueueTime { get; set; }

    public DateTime? SentTime { get; set; }
}
