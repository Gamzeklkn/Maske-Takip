﻿using Business.Abstract;
using Entities.Concrete;
using MernisServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    //Çıplak class kalmasın
    public class PersonManager : IApplicantService
    {
        //encapsulation
        public void ApplyForMask(Person person)
        {
            
        }

        public List<Person> GetList()
        {
            return null;
        }
        
        public bool CheckPerson(Person person) 
        {
            KPSPublicSoapClient client=new KPSPublicSoapClient(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap);

            return client.TCKimlikNoDogrulaAsync
                (new TCKimlikNoDogrulaRequest(new TCKimlikNoDogrulaRequestBody(person.NationalIdentity, person.FirstName, person.LastName, person.DateOfBirthyear)))
                .Result.Body.TCKimlikNoDogrulaResult;

        }

    }


}
