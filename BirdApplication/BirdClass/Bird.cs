using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using BirdApplication.Models;

namespace BirdApplication.BirdClass
{
        interface IBirdBehaviour
        {
            string Walk();
            string Swim();
            string Fly();
            string Jump();
            BirdModel BirdDetail(List<string> behavioursList);
        }
        abstract class CommonFeature : IBirdBehaviour
        {
            public BirdModel birds;
            public string Walk()
            {
            return ("Walk");
            }
            abstract public BirdModel BirdDetail(List<string> behavioursList);
            abstract public string Swim();
            abstract public string Fly();
            abstract public string Jump();
        }

        class Bird : CommonFeature
        {
              public Bird(string birdName)
              {
                    birds = new BirdModel();
                    birds.BirdName = birdName;
                    birds.BirdBehaviourList = new List<string>();
              }
              public string Walk()
              {
                   return("Walk");
              }
              public override string Swim()
              {
                    return("Swim");
              }
              public override string Jump()
              {
                    return("Jump");
              }
              public override string Fly()
              {
                    return("Fly");
              }
             public override BirdModel BirdDetail(List<string> behavioursList)
              {
                    
                    foreach (string behaviour in behavioursList)
                    {
                        if (behaviour.Contains("Fly"))
                        {
                            birds.BirdBehaviourList.Add(Fly());
                        }
                        if (behaviour.Contains("Swim"))
                        {
                            birds.BirdBehaviourList.Add(Swim());
                        }
                        if (behaviour.Contains("Jump"))
                        {
                            birds.BirdBehaviourList.Add(Jump());
                        }
                        if (behaviour.Contains("Walk"))
                        {
                            birds.BirdBehaviourList.Add(Walk());
                        }
                    } 
                    return birds;
            }
    }
}



