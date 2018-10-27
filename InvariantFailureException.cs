using System;

namespace Safety
{
  public class InvariantFailureException : Exception
  {
    public InvariantFailureException() :
        base(@"An invariant in this program was found to be incorrect.
                   This is indicative of faulty assumptions."
            )
    {
    }
  }
}