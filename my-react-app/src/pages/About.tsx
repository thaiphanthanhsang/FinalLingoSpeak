import { useTranslation } from "react-i18next";
import Navbar from "../components/layout/Navbar";
import logo from "../assets/images/logo.png";

const features = [
  { icon: "record_voice_over", key: "listeningSpeaking", color: "bg-blue-50 text-blue-600" },
  { icon: "style", key: "smartFlashcard", color: "bg-cyan-50 text-cyan-600" },
  { icon: "mic", key: "recording", color: "bg-emerald-50 text-emerald-600" },
  { icon: "menu_book", key: "topicLearning", color: "bg-violet-50 text-violet-600" },
];

const learningPath = [
  { step: "1", icon: "category", key: "step1", color: "bg-blue-50 text-blue-600" },
  { step: "2", icon: "style", key: "step2", color: "bg-cyan-50 text-cyan-600" },
  { step: "3", icon: "forum", key: "step3", color: "bg-emerald-50 text-emerald-600" },
  { step: "4", icon: "mic", key: "step4", color: "bg-violet-50 text-violet-600" },
];

export default function About() {
  const { t } = useTranslation();

  return (
    <div className="min-h-screen bg-gradient-to-b from-slate-50 to-white">
      <Navbar />

      <main className="max-w-[900px] mx-auto px-4 md:px-10 py-16 mt-16 md:mt-24 space-y-16">
        {/* Hero */}
        <section className="flex flex-col items-center text-center gap-6">
          <div className="flex items-center gap-3">
            <span className="text-5xl font-black bg-gradient-to-r from-blue-500 to-cyan-500 bg-clip-text text-transparent">
              Ling
            </span>
            <img src={logo} alt="logo" className="h-14 w-14" />
            <span className="text-5xl font-black bg-gradient-to-r from-blue-500 to-cyan-500 bg-clip-text text-transparent">
              Speak
            </span>
          </div>
          <p className="text-xl text-slate-500 max-w-lg leading-relaxed">
            {t("about.heroDescription")}
          </p>
          <span className="inline-flex items-center gap-1.5 px-4 py-1.5 rounded-full bg-blue-50 text-blue-600 text-sm font-semibold border border-blue-100">
            <span className="material-symbols-outlined text-[16px]">info</span>
            {t("about.version")}
          </span>
        </section>

        {/* Mission */}
        <section className="bg-gradient-to-r from-blue-500 to-cyan-500 rounded-3xl p-8 text-white text-center shadow-lg">
          <span className="material-symbols-outlined text-4xl mb-3 block">emoji_objects</span>
          <h2 className="text-2xl font-black mb-3">{t("about.missionTitle")}</h2>
          <p className="text-blue-50 leading-relaxed max-w-xl mx-auto">
            {t("about.missionText")}
          </p>
        </section>

        {/* Features */}
        <section>
          <h2 className="text-2xl font-black text-slate-800 mb-6 text-center">{t("about.featuresTitle")}</h2>
          <div className="grid grid-cols-1 sm:grid-cols-2 gap-4">
            {features.map((f) => (
              <div
                key={f.key}
                className="flex items-start gap-4 p-5 bg-white rounded-2xl border border-slate-100 shadow-sm hover:shadow-md transition"
              >
                <div className={`w-11 h-11 rounded-xl flex items-center justify-center flex-shrink-0 ${f.color}`}>
                  <span className="material-symbols-outlined text-[22px]">{f.icon}</span>
                </div>
                <div>
                  <p className="font-bold text-slate-800">{t(`about.features.${f.key}.title`)}</p>
                  <p className="text-sm text-slate-500 mt-0.5 leading-relaxed">{t(`about.features.${f.key}.desc`)}</p>
                </div>
              </div>
            ))}
          </div>
        </section>

        {/* Learning Path */}
        <section>
          <h2 className="text-2xl font-black text-slate-800 mb-2 text-center">{t("about.learningPathTitle")}</h2>
          <p className="text-center text-slate-500 mb-6 max-w-lg mx-auto">
            {t("about.learningPathSubtitle")}
          </p>
          <div className="grid grid-cols-1 sm:grid-cols-2 gap-4">
            {learningPath.map((p) => (
              <div
                key={p.step}
                className="flex items-start gap-4 p-5 bg-white rounded-2xl border border-slate-100 shadow-sm hover:shadow-md transition"
              >
                <div className={`w-11 h-11 rounded-xl flex items-center justify-center flex-shrink-0 ${p.color}`}>
                  <span className="material-symbols-outlined text-[22px]">{p.icon}</span>
                </div>
                <div>
                  <p className="font-bold text-slate-800">
                    {t("about.step")} {p.step}: {t(`about.learningPath.${p.key}.title`)}
                  </p>
                  <p className="text-sm text-slate-500 mt-0.5 leading-relaxed">{t(`about.learningPath.${p.key}.desc`)}</p>
                </div>
              </div>
            ))}
          </div>
        </section>

        {/* Dev info */}
        <section className="text-center space-y-2 pb-8">
          <p className="text-slate-400 text-sm">
            {t("about.developedBy")}{" "}
            <span className="font-semibold text-slate-600">{t("about.team")}</span>
          </p>
          <p className="text-slate-400 text-sm">
            {t("about.copyright")}
          </p>
        </section>
      </main>
    </div>
  );
}
