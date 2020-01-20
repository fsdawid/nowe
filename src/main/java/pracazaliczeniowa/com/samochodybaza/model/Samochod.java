package pracazaliczeniowa.com.samochodybaza.model;

import javax.persistence.*;
import java.util.HashSet;
import java.util.Set;
@Entity
public class Samochod {
    @Id
    @GeneratedValue
    private Long Id;
    private String Data_produkcji;
    private String Koniec_przegladu;
    private String Koniec_ubezpieczenia;
    @ManyToMany (mappedBy = "Samochod_")
    private Set<Wyposazenie>Wyposazenie_=new HashSet<>();
    @ManyToOne
    private Model Model;

    public Samochod() {
    }

    public Samochod(Long id_modelu, String data_produkcji, String koniec_przegladu, String koniec_ubezpiczenia, Set<Wyposazenie> wyposazenie_, pracazaliczeniowa.com.samochodybaza.model.Model model) {
        Data_produkcji = data_produkcji;
        Koniec_przegladu = koniec_przegladu;
        Koniec_ubezpieczenia = koniec_ubezpiczenia;
        Wyposazenie_ = wyposazenie_;
        Model = model;
    }

    public Set<Wyposazenie> getWyposazenie_() {
        return Wyposazenie_;
    }

    public void setWyposazenie_(Set<Wyposazenie> wyposazenie_) {
        Wyposazenie_ = wyposazenie_;
    }

    public pracazaliczeniowa.com.samochodybaza.model.Model getModel() {
        return Model;
    }

    public void setModel(pracazaliczeniowa.com.samochodybaza.model.Model model) {
        Model = model;
    }

    public Long getId() {
        return Id;
    }

    public void setId(Long id) {
        Id = id;
    }



    public String getData_produkcji() {
        return Data_produkcji;
    }

    public void setData_produkcji(String data_produkcji) {
        Data_produkcji = data_produkcji;
    }

    public String getKoniec_przegladu() {
        return Koniec_przegladu;
    }

    public void setKoniec_przegladu(String koniec_przegladu) {
        Koniec_przegladu = koniec_przegladu;
    }

    public String getKoniec_ubezpiczenia() {
        return Koniec_ubezpieczenia;
    }

    public void setKoniec_ubezpiczenia(String koniec_ubezpiczenia) {
        Koniec_ubezpieczenia = koniec_ubezpiczenia;
    }

    public Set<Wyposazenie> getSamDoWyp() {
        return Wyposazenie_;
    }

    public void setSamDoWyp(Set<Wyposazenie> samDoWyp) {
        Wyposazenie_ = samDoWyp;
    }

    @Override
    public String toString() {
        return "Samochod{" +
                "Id=" + Id +
                ", Data_produkcji='" + Data_produkcji + '\'' +
                ", Koniec_przegladu='" + Koniec_przegladu + '\'' +
                ", Koniec_ubezpiczenia='" + Koniec_ubezpieczenia + '\'' +
                ", Wyposazenie_=" + Wyposazenie_ +
                ", Model=" + Model +
                '}';
    }
}


