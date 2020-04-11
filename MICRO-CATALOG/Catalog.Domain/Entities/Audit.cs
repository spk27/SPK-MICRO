
using System;

namespace Spk.Catalog.Domain.Entities {
  public class Audit {
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string User { get; set; }
    public string Action { get; set; }
    public bool IsError { get; set; }
    public string Message { get; set; }
  }
}