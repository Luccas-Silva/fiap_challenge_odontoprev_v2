package com.Java_Odontoprev_v2.controller;

import com.Java_Odontoprev_v2.repository.ClienteRepository;
import com.Java_Odontoprev_v2.repository.ConsultaRepository;
import lombok.RequiredArgsConstructor;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.validation.annotation.Validated;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestMapping;

@Controller
@RequestMapping("/consulta")
@RequiredArgsConstructor
@Validated
public class ConsultaController {

    @Autowired
    private ConsultaRepository consultaRepository;

    @GetMapping
    public String listaConsulta() {
        return "";
    }

    @GetMapping
    public String novoConsulta() {
        return "";
    }

    @PostMapping
    public String salvarConsulta() {
        return "";
    }

    @GetMapping
    public String editarConsulta() {
        return "";
    }

    @GetMapping
    public String deletarConsulta() {
        return "";
    }

}
