using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunScript : MonoBehaviour
{

    public abstract class Gun
    {
        int RateOfFire;
        int AmmoCapacity;
        int Damage;
        GameObject GunPrefab;
        public abstract void ShootGun();

        protected Gun(int rateOfFire, int ammoCapacity, int damage, GameObject gunPrefab)
        {
            RateOfFire = rateOfFire;
            AmmoCapacity = ammoCapacity;
            Damage = damage;
            GunPrefab = gunPrefab;


        }
    }
    public class auto : Gun
    {
        public override void ShootGun()
        {

        }
        public auto(int rateOfFire, int ammoCapacity, int damage, GameObject gunPrefab) : base(rateOfFire, ammoCapacity, damage, gunPrefab)
        {

        }
    }

    public class revolver : Gun
    {
        public override void ShootGun()
        {

        }
        public revolver(int rateOfFire, int ammoCapacity, int damage, GameObject gunPrefab) : base(rateOfFire, ammoCapacity, damage, gunPrefab)
        {

        }
    }

    public class rpg : Gun
    {
        public override void ShootGun()
        {

        }
        public rpg(int rateOfFire, int ammoCapacity, int damage, GameObject gunPrefab) : base(rateOfFire, ammoCapacity, damage, gunPrefab)
        {

        }
    }

    public class sniper : Gun
    {
        public override void ShootGun()
        {

        }
        public sniper(int rateOfFire, int ammoCapacity, int damage, GameObject gunPrefab) : base(rateOfFire, ammoCapacity, damage, gunPrefab)
        {

        }
    }






    void Start()
    {

    }


    void Update()
    {

    }
}
