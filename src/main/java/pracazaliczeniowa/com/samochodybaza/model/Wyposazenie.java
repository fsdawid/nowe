package pracazaliczeniowa.com.samochodybaza.model;

import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.ManyToMany;
import java.util.HashSet;
import java.util.Set;
@Entity
public class Wyposazenie {
    @Id
    private Long Id;
    private String Nazwa_opcji;
    @ManyToMany
    private Set<Samochod>Samochod_=new HashSet<>();

    public Wyposazenie() {
    }

    public Wyposazenie(Long id, String nazwa_opcji, Set<Samochod> wypDoSam) {
        Id = id;
        Nazwa_opcji = nazwa_opcji;
        Samochod_ = wypDoSam;
    }

    public Long getId() {
        return Id;
    }

    public void setId(Long id) {
        Id = id;
    }

    public String getNazwa_opcji() {
        return Nazwa_opcji;
    }

    public void setNazwa_opcji(String nazwa_opcji) {
        Nazwa_opcji = nazwa_opcji;
    }

    public Set<Samochod> getWypDoSam() {
        return Samochod_;
    }

    public void setWypDoSam(Set<Samochod> wypDoSam) {
        Samochod_= wypDoSam;
    }

    @Override
    public String toString() {
        return "Wyposazenie{" +
                "Id=" + Id +
                ", Nazwa_opcji='" + Nazwa_opcji + '\'' +
                ", Samochod_=" + Samochod_ +
                '}';
    }
}


