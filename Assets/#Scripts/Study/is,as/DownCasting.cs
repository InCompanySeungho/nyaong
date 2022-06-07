using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownCasting : MonoBehaviour
{
    // C++ �� �ٿ�ĳ���ð� ���õ� ����Ƽ ���� ������ is,as 

    // is : ��ü�� �ش� ���࿡ �ش��ϴ��� �˻��Ͽ�, ����� bool ������ ��ȯ.
    // as : ���� ��ȯ �����ڿ� ���� ����. but ����ȯ �����ڴ� ��ȯ ���н� ���ܸ� ��������, as �����ڴ� ��ü ������ null �� �����.

    public class Mammal // mammal = ������
    {
     public void Nurse()
        {

        }
    }
    class Dog : Mammal
    {
        public void Bark(){}
        
    }
    class Cat : Mammal
    {
        public void Meow(){}
    }

    void normalDown()
    {
        Mammal m = new Mammal();
        m.Nurse();

        m = new Dog();
        m.Nurse();

        Dog dog = (Dog)m; // �ٿ�ĳ����
        dog.Nurse(); // ������ m �� ����Ű�� �ִ� ����
        dog.Bark(); // Dog �̱⿡ �����ϴ�.

        m = new Cat();
        m.Nurse();

        Cat cat = (Cat)m;
        cat.Nurse();
        cat.Meow();
    }

    void IsAs()
    {
        Mammal m = new Dog();
        Dog dog;

        if (m is Dog) // m �� Dog �� ����Ű�� �ֳ�?
        {
            dog = (Dog)m; // �ٿ�ĳ����
            dog.Bark();
        }


        Mammal m2 = new Cat();
        Cat cat = m2 as Cat; // m2�� Cat ���� ����ȯ�϶�
        if(cat != null) // m2 �� Cat �� ����Ű�� �ֱ� ������, �ٿ�ĳ������ ���� �ʾƵ� �����ϴ�. m2 = new Mammal() �̾��ٸ� �Ұ���.
        {
            cat.Meow();
        }

    }
    private void Start()
    {

    }
}
