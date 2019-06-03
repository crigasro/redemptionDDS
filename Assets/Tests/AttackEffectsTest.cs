using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor;

namespace Test
{
    public class AttackEffectsTest
    {
        float timeCounter = 0f;

        [UnityTest]
        public IEnumerator CheckPotionsEffectOnAttack()
        {
            GameManager gameManager = new GameObject().AddComponent<GameManager>();
            AssetManager assetManager = new GameObject().AddComponent<AssetManager>();
            GameObject player = GameObject.Instantiate(Resources.Load("Zombie")) as GameObject;



            //DISPARAMOS UN PROYECTIL
            GameObject projectile1 = GameObject.Instantiate(Resources.Load("Projectile")) as GameObject;
            //COMPROBAR QUE EL PROYECTIL SE CREA DE VERDAD
            Assert.IsNotNull(projectile1);

            //SE ESPERA 1 SEGUNDO
            timeCounter = 0f;
            while (timeCounter < 0.01f) { timeCounter += Time.deltaTime; yield return null; }
            //COMPROBAR QUE EL PROYECTIL NORMAL ES LA BOLA DE MIERDA
            Assert.AreEqual(projectile1.transform.Find("Sprite").GetComponent<SpriteRenderer>().sprite.name, "black_ball");




            //LE DAMOS EL PODER DEL FUEGOOOOOOOOOO
            gameManager.giveFire();
            //DISPARAMOS OTRO PROYECTIL
            GameObject projectile2 = GameObject.Instantiate(Resources.Load("Projectile")) as GameObject;
            //COMPROBAR QUE EL PROYECTIL SE CREA DE VERDAD
            Assert.IsNotNull(projectile2);

            //SE ESPERA 0.25f SEGUNDOS
            timeCounter = 0f;
            while (timeCounter < 0.01f) { timeCounter += Time.deltaTime; yield return null; }
            Assert.IsNotNull(projectile2);
            //COMPROBAR QUE EL PROYECTIL ES UNA BOLA DE FUEGO PODEROSA
            Assert.AreEqual(projectile2.transform.Find("Sprite").GetComponent<SpriteRenderer>().sprite.name, "fireball_1");




            //LE DAMOS EL PODER DEL HIELOOOOOO
            gameManager.giveIce();
            //DISPARAMOS OTRO PROYECTIL
            GameObject projectile3 = GameObject.Instantiate(Resources.Load("Projectile")) as GameObject;
            //COMPROBAR QUE EL PROYECTIL SE CREA DE VERDAD
            Assert.IsNotNull(projectile3);

            //SE ESPERA 0.25f SEGUNDOS
            timeCounter = 0f;
            while (timeCounter < 0.01f) { timeCounter += Time.deltaTime; yield return null; }
            //COMPROBAR QUE EL PROYECTIL ES UNA BOLA DE FUEGO VERDE POR EL PODER DEL HIELO
            Assert.AreEqual(projectile3.transform.Find("Sprite").GetComponent<SpriteRenderer>().sprite.name, "fireball_1");
            Assert.AreEqual(projectile3.transform.Find("Sprite").GetComponent<SpriteRenderer>().color, IceAttack.AttackColor);


            yield return null;
        }
    }
}
