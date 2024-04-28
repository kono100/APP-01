using Gestao.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Gestao.Data
{
    public class AppDBInicializer
    {
        public static void Seed(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<IESContext>();
                context.Database.EnsureCreated();





                //Criar Morador se estiver vazias
                if (!context.Morador.Any())
                {
                    context.Morador.AddRange(new List<Morador>()
                    {
                        new Morador()
                        {
                            Nome = "Rafael Gomes",
                            Endereco = "A",
                            NumeroAP = "6",
                            DataNasc = "22/12/1977",
                            CPF = "111.111.111-55",
                            Telefone = "16985630129"


                        },

                        new Morador()
                        {
                            Nome = "Thiago Campos",
                            Endereco = "B",
                            NumeroAP = "44",
                            DataNasc = "11/11/2000",
                            CPF = "442.124.348-53",
                            Telefone = "16988630184"
                        },

                        new Morador()
                        {
                            Nome = "Tereza Silva",
                            Endereco = "C",
                            NumeroAP = "22",
                            DataNasc = "09/04/1960",
                            CPF = "111.111.111-55",
                            Telefone = "16984630116"
                        },

                    });
                    context.SaveChanges();

                }






                //Criar Visitante se estiver vazias
                if (!context.Visitante.Any())
                {
                    context.Visitante.AddRange(new List<Visitante>()
                    {

                        new Visitante()
                        {
                            Nome = "Jose Carlos Perreira",
                            CPF = "217.082.333-94",
                            DataNasc = "12/02/1993",
                            EndDate =  "04/02/2024",
                            Observacao = "Pegar um notbook",
                            fk_MoradorID = 2
                        },

                        new Visitante()
                        {
                            Nome = "Augusto da Silva",
                            CPF = "121.822.343-48",
                            DataNasc = "11/05/1965",
                            EndDate =  "21/12/2023",
                            Observacao = "Visitar a Mãe",
                            fk_MoradorID = 1
                        },

                        new Visitante()
                        {
                            Nome = "Pedro Alvares Cabral",
                            CPF = "111.111.111-11",
                            DataNasc = "05/11/1467",
                            EndDate =  "22/04/1500",
                            Observacao = "Pegar umas especiarias",
                            fk_MoradorID = 2
                        },



                    });
                    context.SaveChanges();

                }






                //Criar Veiculo se estiver vazias
                if (!context.Veiculo.Any())
                {
                    context.Veiculo.AddRange(new List<Veiculo>()
                    {
                        new Veiculo()
                        {
                            Placa = "DOK2A20",
                            Marca = "Mercedes",
                            Modelo = "Sprinter",
                            Cor = "Branco",
                            Tag = "SIM",
                            Segunda = true,
                            HrEntSeg = "00:00",
                            HrSaiSeg = "23:59",
                            Terca = true,
                            HrEntTer = "00:00",
                            HrSaiTer = "23:59",
                            Quarta = true,
                            HrEntQua = "00:00",
                            HrSaiQua = "23:59",
                            Quinta = true,
                            HrEntQui = "00:00",
                            HrSaiQui = "23:59",
                            Sexta = true,
                            HrEntSex = "00:00",
                            HrSaiSex = "23:59",
                            Sabado = true,
                            HrEntSab = "00:00",
                            HrSaiSab = "23:59",
                            Domingo = true,
                            HrEntDom = "00:00",
                            HrSaiDom = "23:59",
                            Todos_os_Dias = true,
                            fk_MoradorID = 1
                        },

                        new Veiculo()
                        {
                            Placa = "OTM2022",
                            Marca = "vw",
                            Modelo = "Saveiro",
                            Cor = "Vermelha",
                            Tag = "SIM",
                            Segunda = true,
                            HrEntSeg = "00:00",
                            HrSaiSeg = "23:59",
                            Terca = true,
                            HrEntTer = "00:00",
                            HrSaiTer = "23:59",
                            Quarta = true,
                            HrEntQua = "00:00",
                            HrSaiQua = "23:59",
                            Quinta = true,
                            HrEntQui = "00:00",
                            HrSaiQui = "23:59",
                            Sexta = true,
                            HrEntSex = "00:00",
                            HrSaiSex = "23:59",
                            Sabado = true,
                            HrEntSab = "00:00",
                            HrSaiSab = "23:59",
                            Domingo = true,
                            HrEntDom = "00:00",
                            HrSaiDom = "23:59",
                            Todos_os_Dias = true,
                            fk_MoradorID = 1
                        },

                        new Veiculo()
                        {
                            Placa = "BRA2E19",
                            Marca = "Volksvagem",
                            Modelo = "Gol",
                            Cor = "Preto",
                            Tag = "SIM",
                            Segunda = true,
                            HrEntSeg = "00:00",
                            HrSaiSeg = "23:59",
                            Terca = true,
                            HrEntTer = "00:00",
                            HrSaiTer = "23:59",
                            Quarta = true,
                            HrEntQua = "00:00",
                            HrSaiQua = "23:59",
                            Quinta = true,
                            HrEntQui = "00:00",
                            HrSaiQui = "23:59",
                            Sexta = true,
                            HrEntSex = "00:00",
                            HrSaiSex = "23:59",
                            Sabado = true,
                            HrEntSab = "00:00",
                            HrSaiSab = "23:59",
                            Domingo = true,
                            HrEntDom = "00:00",
                            HrSaiDom = "23:59",
                            Todos_os_Dias = true,
                            fk_MoradorID = 2
                        },


                        new Veiculo()
                        {
                            Placa = "RIO2A18",
                            Marca = "BMW",
                            Modelo = "X8",
                            Cor = "Preto",
                            Tag = "SIM",
                            Segunda = true,
                            HrEntSeg = "00:00",
                            HrSaiSeg = "23:59",
                            Terca = true,
                            HrEntTer = "00:00",
                            HrSaiTer = "23:59",
                            Quarta = true,
                            HrEntQua = "00:00",
                            HrSaiQua = "23:59",
                            Quinta = true,
                            HrEntQui = "00:00",
                            HrSaiQui = "23:59",
                            Sexta = true,
                            HrEntSex = "00:00",
                            HrSaiSex = "23:59",
                            Sabado = true,
                            HrEntSab = "00:00",
                            HrSaiSab = "23:59",
                            Domingo = true,
                            HrEntDom = "00:00",
                            HrSaiDom = "23:59",
                            Todos_os_Dias = true,
                            fk_MoradorID = 2
                        },
                    });
                    context.SaveChanges();

                }






                //Criar Reservas se estiver vazias
                if (!context.Reservas.Any())
                {
                    context.Reservas.AddRange(new List<Reservas>()
                    {
                        new Reservas()
                        {
                            Nome = "Area de Churrasco",
                            DataHoraRes = new DateTime(2023,10,11),
                            DuracaoReserva = "5",
                            Status = "Desativado",
                            fk_MoradorID = 2
                        },

                        new Reservas()
                        {
                            Nome = "Area de Festa",
                            DataHoraRes = new DateTime(2024,01,15),
                            DuracaoReserva = "6",
                            Status = "Pendente",
                            fk_MoradorID = 1
                        },

                        new Reservas()
                        {
                            Nome = "Sala de Reunião",
                            DataHoraRes = new DateTime(2024,02,26),
                            DuracaoReserva = "2",
                            Status = "Ativo",
                            fk_MoradorID = 3
                        },


                        new Reservas()
                        {
                            Nome = "Piscina",
                            DataHoraRes = new DateTime(2023,12,03),
                            DuracaoReserva = "4",
                            Status = "Pendente",
                            fk_MoradorID = 1
                        },

                        new Reservas()
                        {
                            Nome = "Area de Festa",
                            DataHoraRes = new DateTime(2023,12,21),
                            DuracaoReserva = "6",
                            Status = "Ativo",
                            fk_MoradorID = 1
                        },

                    });
                    context.SaveChanges();











                }
            }
        }
    }
}
