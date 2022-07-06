using ClubBAISTGQL.Models;

namespace ClubBAISTGQL.GraphQL
{
  public class Subscription
  {
    [Subscribe]
    [Topic]
    public TeeTime OnTeeTimeAdded([EventMessage] TeeTime teeTime) => teeTime;
  }
}