package pracazaliczeniowa.com.samochodybaza.tools;

import org.springframework.context.ApplicationListener;
import org.springframework.context.event.ContextRefreshedEvent;
import org.springframework.stereotype.Component;
import pracazaliczeniowa.com.samochodybaza.model.Marka;
import pracazaliczeniowa.com.samochodybaza.model.Model;
import pracazaliczeniowa.com.samochodybaza.model.Samochod;
import pracazaliczeniowa.com.samochodybaza.model.Wyposazenie;
import pracazaliczeniowa.com.samochodybaza.repositories.MarkaRepository;
import pracazaliczeniowa.com.samochodybaza.repositories.ModelRepository;
import pracazaliczeniowa.com.samochodybaza.repositories.SamochodRepository;
import pracazaliczeniowa.com.samochodybaza.repositories.WyposazenieRepository;

@Component
public class DBInflater implements ApplicationListener<ContextRefreshedEvent> {

    private MarkaRepository markaRepository;
    private ModelRepository modelRepository;
    private SamochodRepository samochodRepository;
    private WyposazenieRepository wyposazenieRepository;

    public DBInflater(MarkaRepository markaRepository, ModelRepository modelRepository, SamochodRepository samochodRepository, WyposazenieRepository wyposazenieRepository) {
        this.markaRepository = markaRepository;
        this.modelRepository = modelRepository;
        this.samochodRepository = samochodRepository;
        this.wyposazenieRepository = wyposazenieRepository;
    }

    @Override
    public void onApplicationEvent(ContextRefreshedEvent contextRefreshedEvent) {
        initData();

    }

    private void initData() {
        Marka Audi = new Marka("Audi");
        Model A4 = new Model("A4");
        Samochod AudiA4 = new Samochod("12.12.2004", "1.02.2021", "21.12.2024");
        Wyposazenie standardowe = new Wyposazenie("klimatyzacja, abs");

        AudiA4.getWyposazenie_()add.(standardowe)

        markaRepository.save(Audi);
        modelRepository.save(A4);
        samochodRepository.save(AudiA4);
        wyposazenieRepository.save(standardowe);





        Marka BMW = new Marka("BMW");
        Model grandcoupe = new Model("520");
        Samochod BMWgranscoupe = new Samochod("12.12.2020", "1.12.2021", "21.11.2024");
        Wyposazenie sup = new Wyposazenie("full");

        markaRepository.save(BMW);
        modelRepository.save(grandcoupe);
        samochodRepository.save(BMWgranscoupe);
        wyposazenieRepository.save(sup);



    }










    }


