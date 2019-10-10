using System;
using System.Collections.Generic;
using System.Linq;

namespace Oc6.Maths.Util
{
    public static class SecretSanta
    {
        public static IList<SecretSantaParticipant> Solve(IList<string> participantNames)
        {
            if (participantNames == null)
            {
                throw new ArgumentNullException(nameof(participantNames));
            }

            int[] listAre = Enumerable.Range(0, participantNames.Count).ToArray();
            listAre.Shuffle();

            int[] listFor = new int[listAre.Length];

            int i;

            for (i = 0; i < listAre.Length - 1; ++i)
            {
                listFor[i + 1] = listAre[i];
            }

            listFor[0] = listAre[i];

            var list = new List<SecretSantaParticipant>(participantNames.Count);

            for (i = 0; i < participantNames.Count; ++i)
            {
                list.Add(new SecretSantaParticipant
                {
                    Are = participantNames[listAre[i]],
                    IsFor = participantNames[listFor[i]],
                });
            }

            return list;
        }
    }
}
