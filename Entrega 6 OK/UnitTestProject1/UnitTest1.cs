using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Microsoft.VisualStudio.QualityTools.UnitTestFramework;

namespace UnitTestProject1
{

    #region TestClass
    [TestClass]
    public class UnitTest1
    {
        #region Atributos
        public Jugador[] jugadores = new Jugador[10];
        public Administrador admin = new Administrador();
        public Persona[] amigos = new Persona[10];
        Jugador jugador2 = new Jugador();
        Partido partido = new Partido();
        Estándar estandar = new Estándar();
        Condicional condicional = new Condicional();
        Solidaria solidario = new Solidaria();
        List<Jugador> _players = new List<Jugador>();
        #endregion
        public void inicializar()
        {
            partido = admin.nuevoPartido(DateTime.Today.AddDays(7));
            for (int i = 0; i < 10; i++)
            {
                jugadores[i] = admin.nuevoJugador(("Agus "+(i.ToString())));
                jugadores[i].handycap = i+1;
                amigos[i] = new Persona();
            }
            for (int i = 0; i < 10;i++ )
            {
                _players.Add(jugadores[9 - i]);
            }
                jugador2 = admin.nuevoJugador("Pedrito");
            jugador2.handycap = 5;
        }
        public void anotarseAPartido(List<Jugador> _players, Partido _unPartido)
        {
            for (int i = 0; i < 10; i++)
            {
                jugadores[i].Inscribirse("Nada", estandar, _unPartido);
                jugadores[i].confirmarInscripcion(jugadores[i].inscripciones.Find(x => x._partido.ID_Partido == _unPartido.ID_Partido));
            }
        }
        public void jugarPartido(Partido _unPartido)
        {
            _unPartido._estado = new EstadoJugada();
            _unPartido.inscripciones.ForEach(x => x._estadoInscripcion=new EstadoJugada());
        }
        public void calificarMuchos(List<Jugador> _jugadores,Partido _partido)
        {
            for (int i = 0; i < _jugadores.Count; i++)
                for (int j = 0; j < _jugadores.Count;j++ )
                    _jugadores.ElementAt(i).calificarJugador(_jugadores.ElementAt(j),
                        _jugadores.ElementAt(j).handycap,"ASD",_partido);
             }
        public void agregarMuchosAmigos()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    jugadores[i].amigos.Add(amigos[j]);
                }
            }
        }
        #region Tests
        #region Tests Inscripciones
        [TestMethod]
        public void PruebaEstandar1()
        {
            Assert.IsTrue(jugador2.Inscribirse("Nada", estandar, partido));
        }
        [TestMethod]
        public void PruebaEstandarNoPuede()
        {
            inicializar();
            for (int i = 0; i < 10; i++) jugadores[i].Inscribirse("Nada", estandar, partido);
            Assert.IsFalse(jugador2.Inscribirse("Nada", estandar, partido));
        }
        [TestMethod]
        public void PruebaCondicionalPuede()
        {
            Assert.IsTrue(jugador2.Inscribirse("Nada", condicional, partido));
        }
        [TestMethod]
        public void PruebaCondicionalNoPuede()
        {
            inicializar();
            for (int i = 0; i < 10; i++) jugadores[i].Inscribirse("Nada", estandar, partido);
            Assert.IsFalse(jugador2.Inscribirse("Nada", condicional, partido));
        }
        [TestMethod]
        public void PruebaEstandarDesplazaCondicional()
        {
            inicializar();
            for (int i = 0; i < 10; i++) jugadores[i].Inscribirse("Nada", condicional, partido);
            Assert.IsTrue(jugador2.Inscribirse("Nada", estandar, partido));
        }

        [TestMethod]
        public void PruebaEstandarDesplazaSolidario()
        {
            inicializar();
            for (int i = 0; i < 10; i++) jugadores[i].Inscribirse("Nada", solidario, partido);
            Assert.IsTrue(jugador2.Inscribirse("Nada", estandar, partido));
        }
        [TestMethod]
        public void PruebaSolidarioReemplazaCondicional()
        {
            inicializar();
            for (int i = 0; i < 10; i++) jugadores[i].Inscribirse("Nada", condicional, partido);
            Assert.IsTrue(jugador2.Inscribirse("Nada", solidario, partido));
        }
        [TestMethod]
        public void PruebaSacarCondicionalPrimero1()
        {
            inicializar();
            for (int i = 0; i < 9; i++) jugadores[i].Inscribirse("Nada", solidario, partido);
            jugadores[9].Inscribirse("Nada", condicional, partido);
            Assert.IsTrue(jugador2.Inscribirse("Nada", estandar, partido) && partido.cantidadCondicional() == 0);

        }
        [TestMethod]
        public void PruebaSacarCondicionalPrimero2()
        {
            inicializar();
            for (int i = 0; i < 9; i++) jugadores[i].Inscribirse("Nada", solidario, partido);
            jugadores[9].Inscribirse("Nada", condicional, partido);
            Assert.IsTrue(jugador2.Inscribirse("Nada", solidario, partido) && partido.cantidadCondicional() == 0);
        }
        [TestMethod]
        public void PruebaInscripcionCondicionalCon10Estandar()
        {
            inicializar();
            for (int i = 0; i < 10; i++) jugadores[i].Inscribirse("Nada", estandar, partido);
            Assert.IsFalse(jugador2.Inscribirse("Nada", condicional, partido));
        }
        [TestMethod]
        public void PruebaInscripcionSolidariaCon10Estandar()
        {
            inicializar();
            for (int i = 0; i < 10; i++) jugadores[i].Inscribirse("Nada", estandar, partido);
            Assert.IsFalse(jugador2.Inscribirse("Nada", solidario, partido));
        }
        [TestMethod]
        public void PruebaConfirmarPartidoOK()
        {
            inicializar();
            for (int i = 0; i < 10; i++)
            {
                jugadores[i].Inscribirse("Nada", estandar, partido);
                jugadores[i].confirmarInscripcion(jugadores[i].inscripciones.Find(x => x._partido.ID_Partido == partido.ID_Partido));
            }
            Assert.IsTrue(partido.estaConfirmado());
        }
        [TestMethod]
        public void PruebaConfirmarPartidoCediendoLugarAOtro()
        {
            inicializar();
            for (int i = 0; i < 10; i++)
            {
                jugadores[i].Inscribirse("Nada", estandar, partido);
                jugadores[i].confirmarInscripcion(jugadores[i].inscripciones.Find(x => x._partido.ID_Partido == partido.ID_Partido));
            }
            jugadores[3].DarseDeBaja(jugadores[3].inscripciones.Find(x => x._partido.ID_Partido == partido.ID_Partido), jugador2);
            Assert.IsTrue(partido.estaConfirmado());
        }
        [TestMethod]
        public void PruebaNoConfirmarPartidoSinCeder()
        {
            inicializar();
            for (int i = 0; i < 10; i++)
            {
                jugadores[i].Inscribirse("Nada", estandar, partido);
                jugadores[i].confirmarInscripcion(jugadores[i].inscripciones.Find(x => x._partido.ID_Partido == partido.ID_Partido));
            }
            jugadores[3].DarseDeBaja(jugadores[3].inscripciones.Find(x => x._partido.ID_Partido == partido.ID_Partido));
            Assert.IsFalse(partido.estaConfirmado() && jugadores[3].estaPenalizado());
        }
        [TestMethod]
        public void PruebaPartidoTieneUnoMenosCuandoSeDaDeBajaUnJugador()
        {
            inicializar();
            for (int i = 0; i < 10; i++)
            {
                jugadores[i].Inscribirse("Nada", estandar, partido);
                jugadores[i].confirmarInscripcion(jugadores[i].inscripciones.Find(x => x._partido.ID_Partido == partido.ID_Partido));
            }
            jugadores[3].DarseDeBaja(jugadores[3].inscripciones.Find(x => x._partido.ID_Partido == partido.ID_Partido));
            Assert.IsTrue(partido.hayLugar());
        }
        [TestMethod]
        public void PruebaCantidadDeAnotadosCon3TiposMenos()
        {
            inicializar();
            for (int i = 0; i < 10; i++)
            {
                jugadores[i].Inscribirse("Nada", estandar, partido);
                jugadores[i].confirmarInscripcion(jugadores[i].inscripciones.Find(x => x._partido.ID_Partido == partido.ID_Partido));
            }
            jugadores[3].DarseDeBaja(jugadores[3].inscripciones.Find(x => x._partido.ID_Partido == partido.ID_Partido));
            jugadores[2].DarseDeBaja(jugadores[2].inscripciones.Find(x => x._partido.ID_Partido == partido.ID_Partido));
            jugadores[1].DarseDeBaja(jugadores[1].inscripciones.Find(x => x._partido.ID_Partido == partido.ID_Partido));
            Assert.IsTrue(partido.inscripciones.Count == 7);
        }
        [TestMethod]
        public void PruebaPermitirAnotarseAUnoDespuesDeQueSeBajaOtro()
        {
            inicializar();
            for (int i = 0; i < 10; i++)
            {
                jugadores[i].Inscribirse("Nada", estandar, partido);
                jugadores[i].confirmarInscripcion(jugadores[i].inscripciones.Find(x => x._partido.ID_Partido == partido.ID_Partido));
            }
            jugadores[3].DarseDeBaja(jugadores[3].inscripciones.Find(x => x._partido.ID_Partido == partido.ID_Partido));
            jugador2.Inscribirse("Nada", estandar, partido);
            jugador2.confirmarInscripcion(jugador2.inscripciones.Find(x => x._partido.ID_Partido == partido.ID_Partido));
            Assert.IsTrue(!partido.hayLugar() && partido.estaConfirmado());
        }

        #endregion
        #region TestsMails
        [TestMethod]
        public void PruebaMails1()
        {
            inicializar();
            jugador2.enviarMail("lalala", jugadores[1]);
            Assert.IsTrue(jugadores[1]._mails.Count == 1);
        }
        [TestMethod]
        public void PruebaMails2()
        {
            inicializar();
            jugador2.agregar(jugadores[1]);
            jugador2.Inscribirse("Nada", estandar, partido);
            Assert.IsTrue(jugadores[1]._mails.Count == 1);
        }
        [TestMethod]
        public void PruebaMails3()
        {
            inicializar();
            jugador2.agregar(jugadores[1]);
            jugador2.Inscribirse("Nada", estandar, partido);
            jugador2.DarseDeBaja(jugador2.inscripciones.Find(x => x._partido.ID_Partido == partido.ID_Partido));
            Assert.IsTrue(jugadores[1]._mails.Count == 2);
        }
        #endregion
        #region Tests Calificaciones
        [TestMethod]
        public void PruebaCalificacionOKLos2Jugaron()
        {
            inicializar();
            for (int i = 0; i < 10; i++)
            {
                jugadores[i].Inscribirse("Nada", estandar, partido);
                jugadores[i].confirmarInscripcion(jugadores[i].inscripciones.Find(x => x._partido.ID_Partido == partido.ID_Partido));

            }
            partido._estado = new EstadoJugada();
            (jugadores[2].inscripciones.Find(x => x._partido.ID_Partido == partido.ID_Partido))._estadoInscripcion = new EstadoJugada();
            (jugadores[1].inscripciones.Find(x => x._partido.ID_Partido == partido.ID_Partido))._estadoInscripcion = new EstadoJugada();
            Assert.IsTrue(jugadores[1].calificarJugador(jugadores[2], 7, "Ma'someno'", partido));
        }
        [TestMethod]
        public void PruebaCalificacionMalCalificado()
        {
            inicializar();
            for (int i = 0; i < 10; i++)
            {
                jugadores[i].Inscribirse("Nada", estandar, partido);
                jugadores[i].confirmarInscripcion(jugadores[i].inscripciones.Find(x => x._partido.ID_Partido == partido.ID_Partido));

            }
            partido._estado = new EstadoJugada();
            (jugadores[1].inscripciones.Find(x => x._partido.ID_Partido == partido.ID_Partido))._estadoInscripcion = new EstadoJugada();
            Assert.IsFalse(jugadores[1].calificarJugador(jugadores[2], 7, "Ma'someno'", partido));
        }
        [TestMethod]
        public void PruebaCalificacionMalCalificador()
        {
            inicializar();
            for (int i = 0; i < 10; i++)
            {
                jugadores[i].Inscribirse("Nada", estandar, partido);
                jugadores[i].confirmarInscripcion(jugadores[i].inscripciones.Find(x => x._partido.ID_Partido == partido.ID_Partido));

            }
            partido._estado = new EstadoJugada();
            (jugadores[2].inscripciones.Find(x => x._partido.ID_Partido == partido.ID_Partido))._estadoInscripcion = new EstadoJugada();
            Assert.IsFalse(jugadores[1].calificarJugador(jugadores[2], 7, "Ma'someno'", partido));
        }
        [TestMethod]
        public void PruebaCalificacionMalPartidoNoJugado()
        {
            inicializar();
            for (int i = 0; i < 10; i++)
            {
                jugadores[i].Inscribirse("Nada", estandar, partido);
                jugadores[i].confirmarInscripcion(jugadores[i].inscripciones.Find(x => x._partido.ID_Partido == partido.ID_Partido));

            }
            (jugadores[2].inscripciones.Find(x => x._partido.ID_Partido == partido.ID_Partido))._estadoInscripcion = new EstadoJugada();
            (jugadores[1].inscripciones.Find(x => x._partido.ID_Partido == partido.ID_Partido))._estadoInscripcion = new EstadoJugada();
            Assert.IsFalse(jugadores[1].calificarJugador(jugadores[2], 7, "Ma'someno'", partido));
        }
        #endregion
        #region Test Penalizaciones
        [TestMethod]
        public void PruebaEstaPenalizado()
        {
            inicializar();
            for (int i = 0; i < 10; i++)
            {
                jugadores[i].Inscribirse("Nada", estandar, partido);
                jugadores[i].confirmarInscripcion(jugadores[i].inscripciones.Find(x => x._partido.ID_Partido == partido.ID_Partido));
            }
            jugadores[3].DarseDeBaja(jugadores[3].inscripciones.Find(x => x._partido.ID_Partido == partido.ID_Partido));
            Assert.IsTrue(jugadores[3].estaPenalizado());

        }
        [TestMethod]
        public void PruebaNoEstaPenalizado()
        {
            inicializar();
            for (int i = 0; i < 10; i++)
            {
                jugadores[i].Inscribirse("Nada", estandar, partido);
                jugadores[i].confirmarInscripcion(jugadores[i].inscripciones.Find(x => x._partido.ID_Partido == partido.ID_Partido));
            }
           // jugadores[3].DarseDeBaja(jugadores[3].inscripciones.Find(x => x._partido.ID_Partido == partido.ID_Partido));
            Assert.IsFalse(jugadores[3].estaPenalizado());

        }
        [TestMethod]
        public void PruebaNoEstaPenalizadoPorqueSeBajoHace8Dias()
        {
            inicializar();
            for (int i = 0; i < 10; i++)
            {
                jugadores[i].Inscribirse("Nada", estandar, partido);
                jugadores[i].confirmarInscripcion(jugadores[i].inscripciones.Find(x => x._partido.ID_Partido == partido.ID_Partido));
            }
            jugadores[3].DarseDeBaja(jugadores[3].inscripciones.Find(x => x._partido.ID_Partido == partido.ID_Partido));
            (jugadores[3].penalizaciones.Find(x => x._jugador == jugadores[3]))._diasDuracion=-1;
            Assert.IsFalse(jugadores[3].estaPenalizado());

        }
        #endregion
        #region Test Amigos
        [TestMethod]
        public void PruebaJugadorTiene10Amigos()
        {
            inicializar();
            agregarMuchosAmigos();
            Assert.IsTrue(jugadores[3].amigos.Count==10);
        }
        [TestMethod]
        public void PruebaPersonaSeTransformaEnJugador()
        {
            inicializar();
            agregarMuchosAmigos();
            Jugador nuevo= admin.nuevoJugador(amigos[1]);
            Assert.IsTrue(jugadores[3].amigos.Exists(x=>x==nuevo));
        }
        [TestMethod]
        public void PruebaJugadorProponeAmigo()
        {
            inicializar();
            agregarMuchosAmigos();
            jugadores[3].proponerAmigo(amigos[1]);
            Assert.IsTrue(admin.solicitudesPendientes.Count==1);
        }
        [TestMethod]
        public void PruebaAceptanTodosYOtroTieneTodosActualizados()
        {
            inicializar();
            agregarMuchosAmigos();

            for (int i=0;i<10;i++)
            jugadores[3].proponerAmigo(amigos[i]);

            for (int i = 0; i < 10; i++)
            admin.nuevoJugador(amigos[i]);
           
            Assert.IsTrue(admin.solicitudesPendientes.Count == 0 && jugadores[5].amigos.TrueForAll(x=>x.sosJugador()));
        }
        [TestMethod]
        public void PruebaRechazaATodosYQuedanTodosIgual()
        {
            inicializar();
            agregarMuchosAmigos();

            for (int i = 0; i < 10; i++)
                jugadores[3].proponerAmigo(amigos[i]);
            for (int i = 0; i < 10; i++)
                admin.rechazarPropuesta(amigos[i],"Porque no sabe jugar.");

            Assert.IsTrue(admin.solicitudesPendientes.Count == 0 &&
                jugadores[5].amigos.TrueForAll(x => x.sosJugador()==false) &&
                admin.solicitudesRechazadas.Count == 10);
        }
        #endregion
        [TestMethod]
        public void PruebaOrdenHandicap()
        {
            inicializar();
            for (int i = 0; i < 10; i++)
            {
                jugadores[i].Inscribirse("Nada", estandar, partido);
                jugadores[i].confirmarInscripcion(jugadores[i].inscripciones.Find(x => x._partido.ID_Partido == partido.ID_Partido));
            }
            List<Jugador> _playersOrdenados = new List<Jugador>();
            _playersOrdenados = partido.ordenarJugadores();
            CollectionAssert.AreEqual(_playersOrdenados, _players);
        }
        [TestMethod]
        public void PruebaOrdenPromedioUltimoPartido()
        {
            inicializar();
            Partido partido2 = admin.nuevoPartido(DateTime.Today.AddDays(-7));
            anotarseAPartido(_players, partido2);
            anotarseAPartido(_players, partido);
            jugarPartido(partido2);
            calificarMuchos(_players, partido2);
            OrdenPromedioUltimoPartido _criterio = new OrdenPromedioUltimoPartido();
            List<Jugador> _playersOrdenados = admin.ordenarJugadores(partido, _criterio);
            CollectionAssert.AreEqual(_playersOrdenados, _players);
        }
        [TestMethod]
        public void PruebaOrdenPromedioUltimos3Partidos()
        {
            inicializar();
            Partido[] partidos = new Partido[3];
            for (int i = 0; i < 3; i++)
            {
                partidos[i] = admin.nuevoPartido(DateTime.Today.AddDays(-7));
                anotarseAPartido(_players, partidos[i]);
                jugarPartido(partidos[i]);
                calificarMuchos(_players, partidos[i]);
            }
            anotarseAPartido(_players, partido);
            OrdenPromedioUltimosNPartidos _criterio = new OrdenPromedioUltimosNPartidos(3);
            _criterio.cantPartidos = 3;
            List<Jugador> _playersOrdenados = admin.ordenarJugadores(partido, _criterio);
            CollectionAssert.AreEqual(_playersOrdenados, _players);
        }
        [TestMethod]
        public void PruebaMixPromedioUltimos3Partidos()
        {
            inicializar();
            Partido[] partidos = new Partido[3];
            for (int i = 0; i < 3; i++)
            {
                partidos[i] = admin.nuevoPartido(DateTime.Today.AddDays(-7));
                anotarseAPartido(_players, partidos[i]);
                jugarPartido(partidos[i]);
                calificarMuchos(_players, partidos[i]);
            }
            anotarseAPartido(_players, partido);
            OrdenMix _criterio = new OrdenMix(3);
            _criterio.promedioNPartidos.cantPartidos = 3;
            List<Jugador> _playersOrdenados = admin.ordenarJugadores(partido, _criterio);
            CollectionAssert.AreEqual(_playersOrdenados, _players);
        }
        #endregion
        #region TestsEquipos
        [TestMethod]
        public void PruebaEquiposParidad()
        {
            inicializar();
            Partido partido2 = admin.nuevoPartido(DateTime.Today.AddDays(-7));
            anotarseAPartido(_players, partido2);
            anotarseAPartido(_players, partido);
            jugarPartido(partido2);
            calificarMuchos(_players, partido2);
            OrdenPromedioUltimoPartido _criterio = new OrdenPromedioUltimoPartido();
            List<Jugador> _playersOrdenados = admin.ordenarJugadores(partido, _criterio);
            DivisionParidad _division = new DivisionParidad();
            admin.dividirJugadores(partido, _division);
            Equipo[] equipos = new Equipo[2];
            equipos[0] = new Equipo();
            equipos[1] = new Equipo();
            equipos[1].agregarJugador(jugadores.ElementAt(0));
            equipos[1].agregarJugador(jugadores.ElementAt(2));
            equipos[1].agregarJugador(jugadores.ElementAt(4));
            equipos[1].agregarJugador(jugadores.ElementAt(6));
            equipos[1].agregarJugador(jugadores.ElementAt(8));
            equipos[0].agregarJugador(jugadores.ElementAt(1));
            equipos[0].agregarJugador(jugadores.ElementAt(3));
            equipos[0].agregarJugador(jugadores.ElementAt(5));
            equipos[0].agregarJugador(jugadores.ElementAt(7));
            equipos[0].agregarJugador(jugadores.ElementAt(9));
            CollectionAssert.AreEqual(equipos[0]._jugadores, partido.m_Equipo[0]._jugadores);
            CollectionAssert.AreEqual(equipos[1]._jugadores, partido.m_Equipo[1]._jugadores);
        }
        [TestMethod]
        public void PruebaEquipos14589()
        {
            inicializar();
            Partido partido2 = admin.nuevoPartido(DateTime.Today.AddDays(-7));
            anotarseAPartido(_players, partido2);
            anotarseAPartido(_players, partido);
            jugarPartido(partido2);
            calificarMuchos(_players, partido2);
            OrdenPromedioUltimoPartido _criterio = new OrdenPromedioUltimoPartido();
            List<Jugador> _playersOrdenados = admin.ordenarJugadores(partido, _criterio);
            Division14589 _division = new Division14589();
            admin.dividirJugadores(partido, _division);
            Equipo[] equipos = new Equipo[2];
            equipos[0] = new Equipo();
            equipos[1] = new Equipo();
            equipos[1].agregarJugador(jugadores.ElementAt(0));
            equipos[0].agregarJugador(jugadores.ElementAt(1));
            equipos[0].agregarJugador(jugadores.ElementAt(2));
            equipos[1].agregarJugador(jugadores.ElementAt(3));
            equipos[1].agregarJugador(jugadores.ElementAt(4));
            equipos[0].agregarJugador(jugadores.ElementAt(5));
            equipos[0].agregarJugador(jugadores.ElementAt(6));
            equipos[1].agregarJugador(jugadores.ElementAt(7));
            equipos[1].agregarJugador(jugadores.ElementAt(8));
            equipos[0].agregarJugador(jugadores.ElementAt(9));
            CollectionAssert.AreEqual(equipos[0]._jugadores, partido.m_Equipo[0]._jugadores);
            CollectionAssert.AreEqual(equipos[1]._jugadores, partido.m_Equipo[1]._jugadores);
        }
        #endregion

    }

}
    #endregion