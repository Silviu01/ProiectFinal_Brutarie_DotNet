# ProiectFinal_Brutarie_DotNet
 Proiect Final
 
 Scrieți un program care să permită gestiunea unei brutării. În acest scop programul va trebui să 
ofere următoarele funcționalități:
1. la pornire să încarce din fișier(e) datele salvate la rularea anterioară.
2. sa afișeze în consolă un meniu de pornire, unde să enumere, numerotate, opțiunile de utilizare 
pe care le are utilizatorul
◦ opțiunile sunt: „Adaugă produse în stoc”, „Vinde produse”, Elimină produse din stoc”, 
„Înregistrează comenzi”, „Afișează stoc și vânzări” și „Închidere program”
3. să permită utilizatorului să introducă opțiunea dorită, să valideze inputul și să îl ceară din nou 
dacă inputul nu corespunde uneia dintre opțiuni
4. dacă inputul e valid să șteargă ecranul și să lanseze în execuție codul corespunzător acelei 
opțiuni, afisând un nou text, cu detalii despre opțiunea selectată.
5. indiferent de opțiunea selectată, meniul care se afișează să aibă și opțiunea „Revenire la ecranul 
anterior”. Dacă utilizatorul o selectează programul să reafișeze meniul principal.
6. la selectarea opțiunii „Adaugă produse în stoc” 
◦ să afișeze textul: 
„Doriți să adăugați:
1) panificatie
2) patiserie
3) cofetarie
0) reveniți la ecranul anterior
◦ să permită utilizatorului să introducă categoria dorită, să valideze inputul și să îl ceară din 
nou dacă inputul nu corespunde uneia dintre categorii
◦ dacă inputul e valid 
▪ să șteargă ecranul 
▪ să afișeze un text care afișează o listă predefinită de
• produse de panificație (pâine, franzelă, baghetă), 
• patiserie (pateu, merdenea, covrig, corn) 
• respectiv cofetărie(ecler, amandină, savarină, tort)
▪ să permită utilizatorului să aleagă produsul dorit, să valideze inputul și să îl ceară din 
nou dacă inputul nu corespunde unui produs
▪ dacă inputul e valid 
• să afiseze în continuare textul „Introduceti numărul de produse:” 
• să citească numărul, să valideze inputul și să îl ceară din nou dacă nu e numeric, 
întreg și mai mare ca zero
• dacă categoria respectivă de produse nu mai există în brutărie 
◦ să pună totalul categoriei respective să fie egal cu numărul de produse noi 
introdus anterior
◦ să afișeze textul „Precizați prețul/bucată” 
◦ să citească prețul, să valideze inputul și să îl ceară din nou dacă nu e numeric și 
mai mare ca zero
◦ să rețină și să folosească noul preț
• dacă categoria respectivă de produse există în brutărie
◦ dacă total bucăți existente este zero și există comenzi pentru acel produs
▪ să onoreze comanda;
• dacă s-au primit destule bucăți să șteargă comanda• dacă nu sunt destule bucăți să reducă numărul de bucăți din comandă cu 
câte produse s-au primit
• în ambele cazuri să treacă produsele onorate din comandă la produse 
vândute
◦ să adune la totalul categoriei respective numărul de produse noi
7. la selectarea opțiunii „Vinde produse”
◦ să afișeze textul „Selectați ce produs vindeți” 
◦ să listeze produsele care au totalul mai mare ca zero.
◦ să permită utilizatorului să introducă produsul dorit, să valideze inputul și să îl ceară din nou
dacă inputul nu corespunde unuia dintre produse
◦ să afiseze „Precizați câte produse vindeți” 
◦ să citească un număr și să valideze inputul să fie întreg, pozitiv și mai mic sau egal decât 
totalul produselor de acel tip.
◦ să scadă acel număr din total produse de acel tip și să adauge înmulțirea dintre numărul de 
produse și prețul / bucată la total vânzări.
8. la selectarea opțiunii „Elimină produse din stoc”
◦ să afișeze textul „Selectați ce produs eliminați”
◦ să listeze produsele care au totalul mai mare ca zero. 
◦ să permită utilizatorului să introducă produsul dorit, să valideze inputul și să îl ceară din nou
dacă inputul nu corespunde unuia dintre produse
◦ să afiseze „Precizați câte produse eliminați”
◦ să citească un număr și să valideze inputul să fie întreg, pozitiv și mai mic decât totalul 
produse de acel tip.
◦ să scadă acel număr din total produse de acel tip.
9. la selectarea opțiunii „Înregistrează comenzi”
• să afișeze textul „Selectați ce produs comandați”
• să listeze produsele care au totalul zero.
• să permită utilizatorului să introducă produsul dorit, să valideze inputul și să îl ceară din nou
dacă inputul nu corespunde unuia dintre produse
• să afiseze „Precizați câte produse comandați”
• să citească un număr și să valideze inputul să fie întreg, pozitiv și mai mic decât totalul 
produse de acel tip.
10. la selectarea opțiunii „Afișează stoc și vânzări”
◦ să afișeze toate produsele din stoc care sunt disponibile pe categorii de produs. Pentru 
fiecare produs să adauge și cantitatea existentă în stoc.
◦ de asemenea să afișeze vânzările pe câte o linie sub forma „Nume produs (preț produs) –
Număr bucăți vândute – Total încasări la acel produs”
◦ La final să afișeze totalul vânzărilor.
11. la selectarea opțiunii „Închidere program” programul să se închidă.
◦ programul să salveze în fișier(e) datele despre stoc, vânzări și comenzi.