package com.Java_Odontoprev_v2.controller;

import com.Java_Odontoprev_v2.repository.ConsultaRepository;
import com.Java_Odontoprev_v2.repository.DentistaRepository;
import lombok.RequiredArgsConstructor;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.validation.annotation.Validated;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestMapping;

@Controller
@RequestMapping("/dentista")
@RequiredArgsConstructor
@Validated
public class DentistaController {

    @Autowired
    private DentistaRepository dentistaRepository;

    @GetMapping
    public String listaDentista() {
        return "";
    }

    @GetMapping
    public String novoDentista() {
        return "";
    }

    @PostMapping
    public String salvarDentista() {
        return "";
    }

    @GetMapping
    public String editarDentista() {
        return "";
    }

    @GetMapping
    public String deletarDentista() {
        return "";
    }

}
