using LanguageExt.TypeClasses;
using System;

namespace Safety.Predicates
{
  public class NonEmptyGuid : Pred<Guid>
  {
    public bool True(Guid value) => Guid.Empty != value;
  }
}