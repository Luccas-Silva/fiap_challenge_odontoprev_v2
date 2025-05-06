package com.Java_Odontoprev_v2.configs;

import java.util.Locale;

public class MessagesConfiguration {
    private static Locale currentLocale = Locale.getDefault();

    public static void setLocale(Locale locale) {
        currentLocale = locale;
    }

    public static String getMessage(String key) {
        switch (currentLocale.getLanguage()) {
            case "pt": // Português
                return getPortugueseMessages(key);
            case "en": // Inglês
                return getEnglishMessages(key);
            case "es": // Espanhol
                return getSpanishMessages(key);
            default:
                return getEnglishMessages(key);
        }
    }

    private static String getPortugueseMessages(String key) {
        switch (key) {
            case "greeting":
                return "Bem-vindo ao sistema!";
            case "farewell":
                return "Obrigado por usar nosso sistema.";
            default:
                return "Mensagem não encontrada!";
        }
    }

    private static String getEnglishMessages(String key) {
        switch (key) {
            case "greeting":
                return "Welcome to the system!";
            case "farewell":
                return "Thank you for using our system.";
            default:
                return "Message not found!";
        }
    }

    private static String getSpanishMessages(String key) {
        switch (key) {
            case "greeting":
                return "¡Bienvenido al sistema!";
            case "farewell":
                return "Adiós";
            default:
                return "Gracias por usar nuestro sistema.";
        }
    }
}
