package com.Java_Odontoprev_v2.controller;

import com.Java_Odontoprev_v2.repository.ClienteRepository;
import lombok.RequiredArgsConstructor;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.validation.annotation.Validated;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestMapping;

@Controller
@RequestMapping("/cliente")
@RequiredArgsConstructor
@Validated
public class ClienteController {

    @Autowired
    private ClienteRepository clienteRepository;

    @GetMapping("/lista")
    public String listaCliente() {
        return "";
    }

    @GetMapping("/novo")
    public String novoCliente() {
        return "";
    }

    @PostMapping
    public String salvarCliente() {
        return "";
    }

    @GetMapping("/editar")
    public String editarCliente() {
        return "";
    }

    @GetMapping("/deletar")
    public String deletarCliente() {
        return "";
    }

}
