using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor;

namespace Test
{
    public class AchievementsTests
    {
        float timeCounter = 0f;


        [UnityTest]
        public IEnumerator CheckAchievementPopup()
        {
            GameObject achivementUnlocked = new GameObject("AchivementUnlocked"); // Panel de obtener logro FAKE
            achivementUnlocked.transform.localScale = new Vector3(0, 0, 0); // Tamaño inicial: 0


            GameObject achivementSystemObject = new GameObject("AchivementSystem");


            AchivementSystem achivementSystem = achivementSystemObject.AddComponent<AchivementSystem>();


            //SE COMPRUEBA QUE EL PANEL DEL LOGRO HA APARECIDO
            Assert.AreEqual(achivementUnlocked.transform.localScale, new Vector3(0, 0, 0));

            //SE DESBLOQUEA EL LOGRO
            achivementSystem.OnNotify(new GameObject(), NotifType.AchivementUnlocked, true);


            //SE ESPERA 1 SEGUNDO
            while (timeCounter < 1)
            {
                timeCounter += Time.deltaTime;
                yield return null;
            }
            timeCounter = 0f;

            //SE COMPRUEBA QUE DETECTA QUE SE HA DESBLOQUEADO EL LOGRO
            Assert.IsTrue(achivementSystem.unlocked);

            //ESPERAR 3 SEGUNDICOS NOMÁS
            while(timeCounter < 4)
            {
                timeCounter += Time.deltaTime;
                yield return null;
            }

            //SE COMPRUEBA QUE EL PANEL DEL LOGRO HA DESAPARECIDO
            Assert.AreEqual(achivementUnlocked.transform.localScale, new Vector3(0, 0, 0));
        }
    }
}
