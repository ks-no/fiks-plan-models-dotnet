using System.Collections.Generic;

namespace KS.Fiks.Plan.Models.V2.Meldingstyper
{
    public class FiksPlanMeldingtypeV2
    {
        // Forespørsler-innsyn
        public const string FinnPlanerForMatrikkelenhet = "no.ks.fiks.plan.v2.innsyn.planerformatrikkelenhet.finn";
        public const string FinnPlanerForAdresse = "no.ks.fiks.plan.v2.innsyn.planerforadresse.finn";
        public const string FinnPlaner = "no.ks.fiks.plan.v2.innsyn.planer.finn";
        public const string FinnDispensasjoner = "no.ks.fiks.plan.v2.innsyn.dispensasjoner.finn";
        public const string FinnPlanbehandlinger = "no.ks.fiks.plan.v2.innsyn.planbehandlinger.finn";
        public const string HentArealplan = "no.ks.fiks.plan.v2.innsyn.arealplan.hent";
        public const string HentGjeldendePlanbestemmelser = "no.ks.fiks.plan.v2.innsyn.gjeldendeplanbestemmelser.hent";
        public const string HentAktoerer = "no.ks.fiks.plan.v2.innsyn.aktoerer.hent";
        public const string HentRelatertePlaner = "no.ks.fiks.plan.v2.innsyn.relaterteplaner.hent";
        public const string HentKodeliste = "no.ks.fiks.plan.v2.innsyn.kodeliste.hent";
        public const string FinnPlandokumenter = "no.ks.fiks.plan.v2.innsyn.plandokumenter.finn";
        public const string HentPlanfil = "no.ks.fiks.plan.v2.innsyn.planfil.hent";
        public const string FinnPlanerForOmraade = "no.ks.fiks.plan.v2.innsyn.planerforomraade.finn";
        public const string HentBboxForPlan = "no.ks.fiks.plan.v2.innsyn.bboxforplan.hent";
        public const string HentPlanomraader = "no.ks.fiks.plan.v2.innsyn.planomraader.hent";
        public const string SjekkMidlertidigForbud = "no.ks.fiks.plan.v2.innsyn.midlertidigforbud.sjekk";

        // Resultat på forespørsler-innsyn
        public const string ResultatFinnPlanerForMatrikkelenhet = "no.ks.fiks.plan.v2.innsyn.planerformatrikkelenhet.resultat";
        public const string ResultatFinnPlanerForAdresse = "no.ks.fiks.plan.v2.innsyn.planerforadresse.resultat";
        public const string ResultatFinnPlaner = "no.ks.fiks.plan.v2.innsyn.planer.resultat";
        public const string ResultatFinnDispensasjoner = "no.ks.fiks.plan.v2.innsyn.dispensasjoner.resultat";
        public const string ResultatFinnPlanbehandlinger = "no.ks.fiks.plan.v2.innsyn.planbehandlinger.resultat";
        public const string ResultatHentArealplan = "no.ks.fiks.plan.v2.innsyn.arealplan.resultat";
        public const string ResultatHentGjeldendePlanbestemmelser = "no.ks.fiks.plan.v2.innsyn.gjeldendeplanbestemmelser.resultat";
        public const string ResultatHentAktoerer = "no.ks.fiks.plan.v2.innsyn.aktoerer.resultat";
        public const string ResultatHentRelatertePlaner = "no.ks.fiks.plan.v2.innsyn.relaterteplaner.resultat";
        public const string ResultatHentKodeliste = "no.ks.fiks.plan.v2.innsyn.kodeliste.resultat";
        public const string ResultatFinnPlandokumenter = "no.ks.fiks.plan.v2.innsyn.plandokumenter.resultat";
        public const string ResultatHentPlanfil = "no.ks.fiks.plan.v2.innsyn.planfil.resultat";
        public const string ResultatFinnPlanerForOmraade = "no.ks.fiks.plan.v2.innsyn.planerforomraade.resultat";
        public const string ResultatHentBboxForPlan = "no.ks.fiks.plan.v2.innsyn.bboxforplan.resultat";
        public const string ResultatHentPlanomraader = "no.ks.fiks.plan.v2.innsyn.planomraader.resultat";
        public const string ResultatSjekkMidlertidigForbud = "no.ks.fiks.plan.v2.innsyn.midlertidigforbud.resultat";

        // Forespørsler-oppdatering
        public const string OpprettArealplan = "no.ks.fiks.plan.v2.oppdatering.arealplan.opprett";
        public const string RegistrertPlanavgrensning = "no.ks.fiks.plan.v2.oppdatering.planavgrensning.registrer";
        public const string RegistrerPlanbehandling = "no.ks.fiks.plan.v2.oppdatering.planbehandling.registrer";
        public const string RegistrerMidlertidigForbudMotTiltak = "no.ks.fiks.plan.v2.oppdatering.midlertidigforbudmottiltak.registrer";
        public const string OppdaterArealplan = "no.ks.fiks.plan.v2.oppdatering.arealplan.oppdater";

        // Resultat på forespørsler-oppdatering
        public const string ResultatOpprettArealplan = "no.ks.fiks.plan.v2.oppdatering.meldingomplanident.resultat";
        public const string ResultatMottat = "no.ks.fiks.plan.v2.oppdatering.mottatt";

        // Ebyggesak 
        public const string RegistrerDispensasjonFraPlan = "no.ks.fiks.plan.v2.oppdatering.dispensasjonplan.registrer";
        public const string OppdaterDispensasjon = "no.ks.fiks.plan.v2.oppdatering.dispensasjon.oppdater";

        public const string ResultatRegistrerDispensasjonFraPlan = "no.ks.fiks.plan.v2.oppdatering.dispensasjonplan.resultat";

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
            FinnPlanerForMatrikkelenhet,
            FinnPlanerForAdresse,
            FinnPlaner,
            FinnDispensasjoner,
            FinnPlanbehandlinger,
            HentArealplan,
            HentGjeldendePlanbestemmelser,
            HentAktoerer,
            HentRelatertePlaner,
            HentKodeliste,
            FinnPlandokumenter,
            HentPlanfil,
            FinnPlanerForOmraade,
            HentBboxForPlan,
            HentPlanomraader,
            SjekkMidlertidigForbud,
            ResultatFinnPlanerForMatrikkelenhet,
            ResultatFinnPlanerForAdresse,
            ResultatFinnPlaner,
            ResultatFinnDispensasjoner,
            ResultatFinnPlanbehandlinger,
            ResultatHentArealplan,
            ResultatHentGjeldendePlanbestemmelser,
            ResultatHentAktoerer,
            ResultatHentRelatertePlaner,
            ResultatHentKodeliste,
            ResultatFinnPlandokumenter,
            ResultatHentPlanfil,
            ResultatFinnPlanerForOmraade,
            ResultatHentBboxForPlan,
            ResultatHentPlanomraader,
            ResultatSjekkMidlertidigForbud
        };

        public static readonly List<string> OppdateringTyper = new List<string>()
        {
            OpprettArealplan,
            RegistrertPlanavgrensning,
            RegistrerPlanbehandling,
            RegistrerMidlertidigForbudMotTiltak,
            OppdaterArealplan,
            ResultatOpprettArealplan,
            ResultatMottat,
            RegistrerDispensasjonFraPlan,
            OppdaterDispensasjon,
            ResultatRegistrerDispensasjonFraPlan
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
            AddSkjemanavnTilDictionary(FinnPlanerForMatrikkelenhet);
            AddSkjemanavnTilDictionary(FinnPlanerForAdresse);
            AddSkjemanavnTilDictionary(FinnPlaner);
            AddSkjemanavnTilDictionary(FinnDispensasjoner);
            AddSkjemanavnTilDictionary(FinnPlanbehandlinger);
            AddSkjemanavnTilDictionary(HentArealplan);
            AddSkjemanavnTilDictionary(HentGjeldendePlanbestemmelser);
            AddSkjemanavnTilDictionary(HentAktoerer);
            AddSkjemanavnTilDictionary(HentRelatertePlaner);
            AddSkjemanavnTilDictionary(HentKodeliste);
            AddSkjemanavnTilDictionary(FinnPlandokumenter);
            AddSkjemanavnTilDictionary(HentPlanfil);
            AddSkjemanavnTilDictionary(FinnPlanerForOmraade);
            AddSkjemanavnTilDictionary(HentBboxForPlan);
            AddSkjemanavnTilDictionary(HentPlanomraader);
            AddSkjemanavnTilDictionary(ResultatFinnPlanerForMatrikkelenhet);
            AddSkjemanavnTilDictionary(ResultatFinnPlanerForAdresse);
            AddSkjemanavnTilDictionary(ResultatFinnPlaner);
            AddSkjemanavnTilDictionary(ResultatFinnDispensasjoner);
            AddSkjemanavnTilDictionary(ResultatHentGjeldendePlanbestemmelser);
            AddSkjemanavnTilDictionary(ResultatHentAktoerer);
            AddSkjemanavnTilDictionary(ResultatHentRelatertePlaner);
            AddSkjemanavnTilDictionary(ResultatHentKodeliste);
            AddSkjemanavnTilDictionary(ResultatHentPlanfil);
            AddSkjemanavnTilDictionary(ResultatFinnPlanerForOmraade);
            AddSkjemanavnTilDictionary(ResultatHentBboxForPlan);
            AddSkjemanavnTilDictionary(OpprettArealplan);
            AddSkjemanavnTilDictionary(RegistrertPlanavgrensning);
            AddSkjemanavnTilDictionary(RegistrerPlanbehandling);
            AddSkjemanavnTilDictionary(OppdaterArealplan);
            AddSkjemanavnTilDictionary(ResultatMottat);
            AddSkjemanavnTilDictionary(RegistrerDispensasjonFraPlan);
            AddSkjemanavnTilDictionary(OppdaterDispensasjon);
            AddSkjemanavnTilDictionary(SjekkMidlertidigForbud);
            AddSkjemanavnTilDictionary(ResultatFinnPlanbehandlinger);
            AddSkjemanavnTilDictionary(ResultatHentArealplan);
            AddSkjemanavnTilDictionary(ResultatFinnPlandokumenter);
            AddSkjemanavnTilDictionary(ResultatHentPlanomraader);
            AddSkjemanavnTilDictionary(ResultatSjekkMidlertidigForbud);
            AddSkjemanavnTilDictionary(RegistrerMidlertidigForbudMotTiltak);
            AddSkjemanavnTilDictionary(ResultatOpprettArealplan);
            AddSkjemanavnTilDictionary(ResultatRegistrerDispensasjonFraPlan);
        }

        private static void AddSkjemanavnTilDictionary(string meldingstype)
        {
            Skjemanavn.Add(meldingstype, $"{meldingstype}.schema.json");
        }

    }
}
