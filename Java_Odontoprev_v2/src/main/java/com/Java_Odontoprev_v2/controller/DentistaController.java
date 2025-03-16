package com.Java_Odontoprev_v2.controller;

import com.Java_Odontoprev_v2.model.Cliente;
import com.Java_Odontoprev_v2.model.Consulta;
import com.Java_Odontoprev_v2.model.Dentista;
import com.Java_Odontoprev_v2.repository.ConsultaRepository;
import com.Java_Odontoprev_v2.repository.DentistaRepository;
import lombok.RequiredArgsConstructor;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.validation.BindingResult;
import org.springframework.validation.annotation.Validated;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.Optional;

@Controller
@RequestMapping("/dentista")
@RequiredArgsConstructor
@Validated
public class DentistaController {

    @Autowired
    private DentistaRepository dentistaRepository;

    @GetMapping("/lista")
    public String listaDentista(Model model) {
        List<Dentista> dentistas = dentistaRepository.findAll();
        model.addAttribute("dentistas", dentistas);
        return "dentistas/lista";
    }

    @GetMapping("/novo")
    public String novoDentista(Model model) {
        model.addAttribute("dentista", new Dentista());
        return "dentista/novo";
    }

    @PostMapping("/salvar")
    public String salvarDentista(@ModelAttribute Dentista dentista, BindingResult result, Model model) {
        if (result.hasErrors()){
            model.addAttribute("dentista", dentista);
            return "dentista/formulario";
        }
        dentistaRepository.save(dentista);
        return "redirect:/dentista/lista";
    }

    @GetMapping("/editar/{cpfCnpj}/")
    public String editarDentista(@PathVariable String cpfCnpj, Model model) {
        Optional<Dentista> dentista = dentistaRepository.findById(cpfCnpj);
        if (dentista.isPresent()){
            model.addAttribute("dentista", dentista.get());
            return "dentista/formulario";
        }
        return "dentista";
    }

    @GetMapping("/editar/{cpfCnpj}")
    public String deletarDentista(@PathVariable String cpfCnpj) {
        dentistaRepository.deleteById(cpfCnpj);
        return "redirect:/dentista/lista";
    }

}
