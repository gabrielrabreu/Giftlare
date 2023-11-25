import translationsPtBR from "./translations/pt-BR.json";
import translationsEn from "./translations/en.json";

type Language = "en" | "pt-BR";

interface Translations {
  [key: string]: string | Translations;
}

const translations: Record<Language, Translations> = {
  en: translationsEn,
  "pt-BR": translationsPtBR,
};

const getUserLanguage = (): Language => {
  return (
    (localStorage.getItem("language") as Language) || navigator.language || "en"
  );
};

export const translate = (path: string): string => {
  const userLanguage = getUserLanguage();

  const keys = path.split(".");
  let currentTranslation: Translations = translations[userLanguage];

  for (const key of keys) {
    currentTranslation = (currentTranslation[key] as Translations) || {};
  }

  return typeof currentTranslation === "string" ? currentTranslation : path;
};
