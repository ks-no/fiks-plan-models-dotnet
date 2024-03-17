using System.Collections.Generic;

namespace KS.Fiks.Plan.Models.V2.Meldingstyper
{
    public class FiksPlanMeldingtypeV2
    {
        // Forespørsler-innsyn
        public const string FinnArealplaner = "no.ks.fiks.plan.v2.innsyn.arealplaner.finn";
        public const string FinnArealplanerForMatrikkelenhet = "no.ks.fiks.plan.v2.innsyn.arealplaner.finn.for.matrikkelenhet";
        public const string FinnArealplanerForAdresse = "no.ks.fiks.plan.v2.innsyn.arealplaner.finn.for.adresse";
        public const string FinnArealplanerForFlate = "no.ks.fiks.plan.v2.innsyn.arealplaner.finn.for.flate";
        public const string FinnDispensasjoner = "no.ks.fiks.plan.v2.innsyn.dispensasjoner.finn";
        public const string FinnPlanbehandlinger = "no.ks.fiks.plan.v2.innsyn.planbehandlinger.finn";
        public const string HentArealplan = "no.ks.fiks.plan.v2.innsyn.arealplan.hent";
        public const string HentGjeldendePlandokumenter = "no.ks.fiks.plan.v2.innsyn.gjeldendeplandokumenter.hent";
        public const string HentAktoerer = "no.ks.fiks.plan.v2.innsyn.aktoerer.hent";
        public const string HentRelatertePlaner = "no.ks.fiks.plan.v2.innsyn.relaterteplaner.hent";
        public const string HentKodeliste = "no.ks.fiks.plan.v2.innsyn.kodeliste.hent";
        public const string HentDokumentfil = "no.ks.fiks.plan.v2.innsyn.dokumentfil.hent";
        public const string HentPlanomraader = "no.ks.fiks.plan.v2.innsyn.planomraader.hent";
        public const string FinnMidlertidigForbudMotTiltak = "no.ks.fiks.plan.v2.innsyn.midlertidigeforbudmottiltak.finn";

        // Resultat på forespørsler-innsyn
        public const string ResultatFinnArealplaner = "no.ks.fiks.plan.v2.innsyn.arealplaner.finn.resultat";
        public const string ResultatFinnDispensasjoner = "no.ks.fiks.plan.v2.innsyn.dispensasjoner.finn.resultat";
        public const string ResultatFinnPlanbehandlinger = "no.ks.fiks.plan.v2.innsyn.planbehandlinger.finn.resultat";
        public const string ResultatHentArealplan = "no.ks.fiks.plan.v2.innsyn.arealplan.hent.resultat";
        public const string ResultatHentGjeldendePlandokumenter = "no.ks.fiks.plan.v2.innsyn.gjeldendeplandokumenter.hent.resultat";
        public const string ResultatHentAktoerer = "no.ks.fiks.plan.v2.innsyn.aktoerer.hent.resultat";
        public const string ResultatHentRelatertePlaner = "no.ks.fiks.plan.v2.innsyn.relaterteplaner.hent.resultat";
        public const string ResultatHentKodeliste = "no.ks.fiks.plan.v2.innsyn.kodeliste.hent.resultat";
        public const string ResultatHentDokumentfil = "no.ks.fiks.plan.v2.innsyn.dokumentfil.hent.resultat";
        public const string ResultatHentPlanomraader = "no.ks.fiks.plan.v2.innsyn.planomraader.hent.resultat";
        public const string ResultatFinnMidlertidigForbud = "no.ks.fiks.plan.v2.innsyn.midlertidigeforbudmottiltak.finn.resultat";

        // Forespørsler-oppdatering
        public const string OpprettArealplan = "no.ks.fiks.plan.v2.oppdatering.arealplan.opprett";
        public const string OppdaterArealplan = "no.ks.fiks.plan.v2.oppdatering.arealplan.oppdater";
        public const string RegistrerPlanavgrensning = "no.ks.fiks.plan.v2.oppdatering.planavgrensning.registrer";
        public const string RegistrerPlanbehandling = "no.ks.fiks.plan.v2.oppdatering.planbehandling.registrer";
        public const string RegistrerMidlertidigForbudMotTiltak = "no.ks.fiks.plan.v2.oppdatering.midlertidigforbudmottiltak.registrer";
        public const string RegistrerPlanomraade = "no.ks.fiks.plan.v2.oppdatering.planomraade.registrer";

        // Resultat på forespørsler-oppdatering
        public const string MottattOpprettArealplan = "no.ks.fiks.plan.v2.oppdatering.arealplan.opprett.mottatt";
        public const string KvitteringOpprettArealplan = "no.ks.fiks.plan.v2.oppdatering.arealplan.opprett.kvittering";
        public const string MottattOppdaterArealplan = "no.ks.fiks.plan.v2.oppdatering.arealplan.oppdater.mottatt";
        public const string KvitteringOppdaterArealplan = "no.ks.fiks.plan.v2.oppdatering.arealplan.oppdater.kvittering";
        public const string MottattRegistrerPlanavgrensning = "no.ks.fiks.plan.v2.oppdatering.planavgrensning.registrer.mottatt";
        public const string KvitteringRegistrerPlanavgrensning = "no.ks.fiks.plan.v2.oppdatering.planavgrensning.registrer.kvittering";
        public const string MottattRegistrerPlanbehandling = "no.ks.fiks.plan.v2.oppdatering.planbehandling.registrer.mottatt";
        public const string KvitteringRegistrerPlanbehandling = "no.ks.fiks.plan.v2.oppdatering.planbehandling.registrer.kvittering";
        public const string MottattRegistrerMidlertidigForbudMotTiltak = "no.ks.fiks.plan.v2.oppdatering.midlertidigforbudmottiltak.registrer.mottatt";
        public const string KvitteringRegistrerMidlertidigForbudMotTiltak = "no.ks.fiks.plan.v2.oppdatering.midlertidigforbudmottiltak.registrer.kvittering";
        public const string MottattRegistrerPlanomraade = "no.ks.fiks.plan.v2.oppdatering.planomraade.registrer.mottatt";
        public const string KvitteringRegistrerPlanomraade = "no.ks.fiks.plan.v2.oppdatering.planomraade.registrer.kvittering";


        // Ebyggesak 
        public const string RegistrerDispensasjon = "no.ks.fiks.plan.v2.oppdatering.dispensasjon.registrer";
        public const string OppdaterDispensasjon = "no.ks.fiks.plan.v2.oppdatering.dispensasjon.oppdater";

        public const string KvitteringRegistrerDispensasjon = "no.ks.fiks.plan.v2.oppdatering.dispensasjon.registrer.kvittering";
        public const string MottattRegistrerDispensasjon = "no.ks.fiks.plan.v2.oppdatering.dispensasjon.registrer.mottatt";
        
        public const string KvitteringOppdaterDispensasjon = "no.ks.fiks.plan.v2.oppdatering.dispensasjon.oppdater.kvittering";
        public const string MottatOppdaterDispensasjon = "no.ks.fiks.plan.v2.oppdatering.dispensasjon.oppdater.mottatt";

        // Feilmeldinger 
        public const string Ugyldigforespoersel = "no.ks.fiks.plan.v2.feilmelding.ugyldigforespoersel";
        public const string Serverfeil = "no.ks.fiks.plan.v2.feilmelding.serverfeil";
        public const string Ikkefunnet = "no.ks.fiks.plan.v2.feilmelding.ikkefunnet";

        
        private static Dictionary<string, string> Skjemanavn;

        public static string GetSkjemanavn(string meldingstypeNavn)
        {
            if (Skjemanavn == null)
            {
                initSkjemanavn();
            }
            return Skjemanavn[meldingstypeNavn];
        }

        public static readonly List<string> InnsynTyper = new List<string>()
        {
            FinnArealplanerForMatrikkelenhet,
            FinnArealplanerForAdresse,
            FinnArealplaner,
            FinnDispensasjoner,
            FinnPlanbehandlinger,
            HentArealplan,
            HentGjeldendePlandokumenter,
            HentAktoerer,
            HentRelatertePlaner,
            HentKodeliste,
            HentDokumentfil,
            FinnArealplanerForFlate,
            HentPlanomraader,
            FinnMidlertidigForbudMotTiltak,
            ResultatFinnArealplaner,
            ResultatFinnDispensasjoner,
            ResultatFinnPlanbehandlinger,
            ResultatHentArealplan,
            ResultatHentGjeldendePlandokumenter,
            ResultatHentAktoerer,
            ResultatHentRelatertePlaner,
            ResultatHentKodeliste,
            ResultatHentDokumentfil,
            ResultatHentPlanomraader,
            ResultatFinnMidlertidigForbud
        };

        public static readonly List<string> OppdateringTyper = new List<string>()
        {
            OpprettArealplan,
            MottattOpprettArealplan,
            KvitteringOpprettArealplan,
            MottattOppdaterArealplan,
            KvitteringOppdaterArealplan,
            RegistrerPlanavgrensning,
            MottattRegistrerPlanavgrensning,
            KvitteringRegistrerPlanavgrensning,
            RegistrerPlanbehandling,
            MottattRegistrerPlanbehandling,
            KvitteringRegistrerPlanbehandling,
            RegistrerMidlertidigForbudMotTiltak,
            MottattRegistrerMidlertidigForbudMotTiltak,
            KvitteringRegistrerMidlertidigForbudMotTiltak,
            OppdaterArealplan,
            MottattOppdaterArealplan,
            KvitteringOppdaterArealplan,
            RegistrerDispensasjon,
            MottattRegistrerDispensasjon,
            KvitteringRegistrerDispensasjon,
            OppdaterDispensasjon,
            MottatOppdaterDispensasjon,
            KvitteringOppdaterDispensasjon,
            RegistrerPlanomraade,
            MottattRegistrerPlanomraade,
            KvitteringRegistrerPlanomraade
        };

        public static readonly List<string> FeilmeldingTyper = new List<string>()
        {
            Ugyldigforespoersel,
            Serverfeil,
            Ikkefunnet
        };

        public static bool IsInnsynType(string meldingstype)
        {
            return InnsynTyper.Contains(meldingstype);
        }

        public static bool IsOppdateringType(string meldingstype)
        {
            return OppdateringTyper.Contains(meldingstype);
        }

        public static bool IsFeilmelding(string meldingstype)
        {
            return FeilmeldingTyper.Contains(meldingstype);
        }

        public static bool IsGyldigProtokollType(string meldingstype)
        {
            return IsInnsynType(meldingstype) || IsOppdateringType(meldingstype) || IsFeilmelding(meldingstype);
        }

        private static void initSkjemanavn()
        {
            Skjemanavn = new Dictionary<string, string>();
            AddSkjemanavnTilDictionary(FinnArealplanerForMatrikkelenhet);
            AddSkjemanavnTilDictionary(FinnArealplanerForAdresse);
            AddSkjemanavnTilDictionary(FinnArealplaner);
            AddSkjemanavnTilDictionary(FinnDispensasjoner);
            AddSkjemanavnTilDictionary(FinnPlanbehandlinger);
            AddSkjemanavnTilDictionary(HentArealplan);
            AddSkjemanavnTilDictionary(HentGjeldendePlandokumenter);
            AddSkjemanavnTilDictionary(HentAktoerer);
            AddSkjemanavnTilDictionary(HentRelatertePlaner);
            AddSkjemanavnTilDictionary(HentKodeliste);
            AddSkjemanavnTilDictionary(HentDokumentfil);
            AddSkjemanavnTilDictionary(FinnArealplanerForFlate);
            AddSkjemanavnTilDictionary(HentPlanomraader);
            AddSkjemanavnTilDictionary(ResultatFinnArealplaner);
            AddSkjemanavnTilDictionary(ResultatFinnDispensasjoner);
            AddSkjemanavnTilDictionary(ResultatHentGjeldendePlandokumenter);
            AddSkjemanavnTilDictionary(ResultatHentAktoerer);
            AddSkjemanavnTilDictionary(ResultatHentRelatertePlaner);
            AddSkjemanavnTilDictionary(ResultatHentKodeliste);
            AddSkjemanavnTilDictionary(ResultatHentDokumentfil);
            AddSkjemanavnTilDictionary(OpprettArealplan);
            AddSkjemanavnTilDictionary(RegistrerPlanavgrensning);
            AddSkjemanavnTilDictionary(RegistrerPlanbehandling);
            AddSkjemanavnTilDictionary(OppdaterArealplan);
            AddSkjemanavnTilDictionary(RegistrerDispensasjon);
            AddSkjemanavnTilDictionary(OppdaterDispensasjon);
            AddSkjemanavnTilDictionary(FinnMidlertidigForbudMotTiltak);
            AddSkjemanavnTilDictionary(ResultatFinnPlanbehandlinger);
            AddSkjemanavnTilDictionary(ResultatHentArealplan);
            AddSkjemanavnTilDictionary(ResultatHentPlanomraader);
            AddSkjemanavnTilDictionary(ResultatFinnMidlertidigForbud);
            AddSkjemanavnTilDictionary(RegistrerMidlertidigForbudMotTiltak);
            AddSkjemanavnTilDictionary(KvitteringOpprettArealplan);
            AddSkjemanavnTilDictionary(KvitteringRegistrerDispensasjon);
            AddSkjemanavnTilDictionary(MottatOppdaterDispensasjon);
            AddSkjemanavnTilDictionary(MottattOppdaterArealplan);
            AddSkjemanavnTilDictionary(MottattOpprettArealplan);
            AddSkjemanavnTilDictionary(MottattRegistrerDispensasjon);
            AddSkjemanavnTilDictionary(MottattRegistrerPlanavgrensning);
            AddSkjemanavnTilDictionary(MottattRegistrerPlanbehandling);
            AddSkjemanavnTilDictionary(MottattRegistrerMidlertidigForbudMotTiltak);
            AddSkjemanavnTilDictionary(KvitteringOppdaterArealplan);
            AddSkjemanavnTilDictionary(KvitteringOppdaterDispensasjon);
            AddSkjemanavnTilDictionary(KvitteringRegistrerPlanavgrensning);
            AddSkjemanavnTilDictionary(KvitteringRegistrerPlanbehandling);
            AddSkjemanavnTilDictionary(KvitteringRegistrerMidlertidigForbudMotTiltak);
            AddSkjemanavnTilDictionary(RegistrerPlanomraade);
            AddSkjemanavnTilDictionary(MottattRegistrerPlanomraade);
            AddSkjemanavnTilDictionary(KvitteringRegistrerPlanomraade);
        }

        private static void AddSkjemanavnTilDictionary(string meldingstype)
        {
            Skjemanavn.Add(meldingstype, $"{meldingstype}.schema.json");
        }

    }
}
