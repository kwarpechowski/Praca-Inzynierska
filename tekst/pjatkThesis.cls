\NeedsTeXFormat{LaTeX2e}
\ProvidesClass{pjatkThesis}[2016/6/21 Wstępna wersja szablonu latex dla prac PJATK]

\RequirePackage[T1]{fontenc}
\RequirePackage[utf8]{inputenc}

\RequirePackage{ifthen}
\RequirePackage{endnotes}

%\RequirePackage[pass,showframe]{geometry}

\RequirePackage{fancyhdr}
\newcommand{\ifthen}[2]{\ifthenelse{#1}{#2}{}}

\makeatletter


\newcounter{@@tcount}

% wymagane pole faculty
\newcommand{\@@faculty}{unknown}
\newcommand{\set@@faculty}[1]{\def\@@faculty{#1}}

% dostępne opcje wyboru
\DeclareOption{inf}{\set@@faculty{inf}}
\DeclareOption{snm}{\set@@faculty{snm}}
\DeclareOption{aw}{\set@@faculty{aw}}
\DeclareOption{zi}{\set@@faculty{zi}}
\DeclareOption{kj}{\set@@faculty{kj}}

% wymagane pole department
\newcommand{\@@department}{unknown}
\newcommand{\set@@department}[1]{\def\@@department{#1}}

% dostępne opcje wyboru
\DeclareOption{abd}{\set@@department{abd}}
\DeclareOption{aio}{\set@@department{aio}}
\DeclareOption{b}{\set@@department{b}}
\DeclareOption{c}{\set@@department{c}}
\DeclareOption{d}{\set@@department{d}}
\DeclareOption{dw}{\set@@department{dw}}
\DeclareOption{e}{\set@@department{e}}
\DeclareOption{e3d}{\set@@department{e3d}}
\DeclareOption{epg}{\set@@department{epg}}
\DeclareOption{f}{\set@@department{f}}
\DeclareOption{g}{\set@@department{g}}
\DeclareOption{h}{\set@@department{h}}

\ProcessOptions
% weryfikacja poprawności wyboru 

\setcounter{@@tcount}{0}
\ProcessOptions
\newcommand{\IW}[1]{\immediate\write16{#1}}{
  \catcode`\+=13
%  \def+{\space}
  \ifthen{\equal{\@@faculty}{unknown}}
    {
      \IW{}
      \IW{Należy określić wydział uczelni}
%      \IW{++++\string\documentclass[wi]{pjatkThesis}}
%      \IW{The available school and department options are defined at}
%      \IW{++++http://engineering.purdue.edu/\string~mark/puthesis/\@@number Options}
      \IW{Przerwano dalsze prace ...}
      \IW{}
      \stop
    }
    
  \ifthen{\(\equal{\@@faculty}{inf} \and \equal{\@@department}{unknown}\)}
    {
      \IW{}
      \IW{Należy określić specjalizację}
%      \IW{++++\string\documentclass[wi]{pjatkThesis}}
%      \IW{The available school and department options are defined at}
%      \IW{++++http://engineering.purdue.edu/\string~mark/puthesis/\@@number Options}
      \IW{Przerwano dalsze prace ...}
      \IW{}
      \stop
    }    
    
}

%\newcommand{\institute}[1]{\def\@institute{#1}}
\newcommand{\department}[1]{\def\@department{#1}}
\newcommand{\album}[1]{\def\@album{#1}}
\newcommand{\type}[1]{\def\@type{#1}}
\newcommand{\supervisor}[1]{\def\@supervisor{#1}}
\newcommand{\location}[1]{\def\@location{#1}}

\LoadClass[12pt,a4paper,twoside]{report}

\newcommand{\maketitlepage}{

% definicja strony tytułowej
    %\newgeometry{hmarginratio=1:1}
    \begin{titlepage}

        %\setlength{\voffset}{-0.5in}
        %\setlength{\topmargin}{-0.2in}
        %\setlength{\textheight}{297mm}
        %\setlength{\textwidth}{170mm}
        %\setlength{\evensidemargin}{0.3in}
        %\setlength{\oddsidemargin}{0.3in}

        \begin{center}  
        \includegraphics[scale=.80]{head}
        \vfill
        {\Large\bfseries\rmfamily\scshape 
            \ifthen{\equal{inf}{\@@faculty}}{Wydział Informatyki}
            \ifthen{\equal{snm}{\@@faculty}}{Wydział Sztuki Nowych Mediów}
            \ifthen{\equal{aw}{\@@faculty}}{Wydział Architektury Wnętrz}
            \ifthen{\equal{zi}{\@@faculty}}{Wydział Zarządzania Informacją}
            \ifthen{\equal{kj}{\@@faculty}}{Wydział Kultury Japonii}
        }\\[\baselineskip]
        {\Large\bfseries\rmfamily\scshape 
            \ifthenelse{\(\equal{\@@faculty}{inf} \and \equal{\@@department}{h}\)}{Katedra Sieci Komputerowych}{Katedra - nieznana}
        }\\[\baselineskip]
        {\large\bfseries\rmfamily\scshape
            \ifthen{\(\equal{\@@faculty}{inf} \and \equal{\@@department}{abd}\)}{Bazy danych}
            \ifthen{\(\equal{\@@faculty}{inf} \and \equal{\@@department}{aio}\)}{Inżynieria oprogramowania i baz danych}
            \ifthen{\(\equal{\@@faculty}{inf} \and \equal{\@@department}{b}\)}{Programowanie systemowe i sieciowe}
            \ifthen{\(\equal{\@@faculty}{inf} \and \equal{\@@department}{c}\)}{Systemy rozproszone i równoległe}
            \ifthen{\(\equal{\@@faculty}{inf} \and \equal{\@@department}{d}\)}{Inteligentne systemy przetwarzania danych}
            \ifthen{\(\equal{\@@faculty}{inf} \and \equal{\@@department}{dw}\)}{Eksploracja WWW}
            \ifthen{\(\equal{\@@faculty}{inf} \and \equal{\@@department}{e}\)}{Multimedia}
            \ifthen{\(\equal{\@@faculty}{inf} \and \equal{\@@department}{e2d}\)}{Multimedia – Animacja 3D}
            \ifthen{\(\equal{\@@faculty}{inf} \and \equal{\@@department}{epg}\)}{Multimedia – Programowanie gier}
            \ifthen{\(\equal{\@@faculty}{inf} \and \equal{\@@department}{f}\)}{Inteligentne metody inżynierii wiedzy}
            \ifthen{\(\equal{\@@faculty}{inf} \and \equal{\@@department}{g}\)}{Programowanie aplikacji biznesowych}
            \ifthen{\(\equal{\@@faculty}{inf} \and \equal{\@@department}{h}\)}{Sieci urządzeń mobilnych}
            \ifthenelse{\( \equal{\@@faculty}{inf} \and \equal{\@@department}{unknown}\)}{nieznana}{}
        }\\[\baselineskip]
        \vfill
        {\Large\bfseries\rmfamily \@author}\\
        {\large \@album}\\[\baselineskip]
        \vfill
        {\LARGE\bfseries\rmfamily \@title}\\[\baselineskip]
        %\vspace*{2cm}
        \vfill
        \end{center}
        \begin{minipage}{0.4\textwidth}
        \begin{flushleft}
        \end{flushleft}
        \end{minipage}
        \begin{minipage}{0.4\textwidth}
        \begin{flushright}
        {\bfseries\small \@type}\\
        {\bfseries  \@supervisor}
        \end{flushright}
        \end{minipage}  
        
        \vfill
        %\vspace*{\fill}
        \begin{center}
        {\large\bfseries\rmfamily \@location, \@date}
        \end{center}
    \end{titlepage}
   
    %\thispagestyle{empty}
    
    %\cleardoublepage

    %\setcounter{page}{1}
    %\restoregeometry
    %\null\newpage
}

\renewenvironment{abstract}{
  \thispagestyle{empty}
  \null \newpage
  \thispagestyle{empty}
  \small
  \begin{center}
    \null\vspace{2em}
    \bfseries \abstractname\vspace{2em}\vspace{0pt}
  \end{center}
  \list{}{
    \setlength{\leftmargin}{15mm}
    \setlength{\rightmargin}{\leftmargin}
  }
  \item\relax
 }
 {\endlist}

\makeatother


\def\@chapter[#1]#2{%
  \ifnum \c@secnumdepth >\m@ne
    \refstepcounter{chapter}%
    \typeout{\@chapapp\space\thechapter.}%
    \setboolean{@@unset}{true}
    \ifthen{\equal{agecon}{\@@dept}}
      {\setboolean{@@unset}{false}\addcontentsline{toc}{chapter}{\protect\uppercase{\@chapapp\ \thechapter. #1}}}
    \ifthen{\equal{ce}{\@@dept}}
      {\setboolean{@@unset}{false}\addcontentsline{toc}{chapter}{\protect\numberline{\thechapter}\uppercase{#1}}}
    \ifthen{\equal{me}{\@@dept}}
      {\setboolean{@@unset}{false}\addcontentsline{toc}{chapter}{\protect\numberline{\thechapter.}\uppercase{#1}}}
    \ifthen{\equal{mse}{\@@dept}}
      {\setboolean{@@unset}{false}\addcontentsline{toc}{chapter}{\protect\uppercase{\@chapapp\ \thechapter. #1}}}
    \ifthen{\boolean{@@unset}}
      {\addcontentsline{toc}{chapter}{\protect\numberline{\thechapter}#1}}
  \else
    \ifthenelse{\equal{ce}{\@@dept}}
      {\addcontentsline{toc}{chapter}{\uppercase{#1}}}
      {\addcontentsline{toc}{chapter}{#1}}
  \fi
  \chaptermark{#1}%
 \addtocontents{lof}{\protect\addvspace{10\p@}}%
 \addtocontents{lot}{\protect\addvspace{10\p@}}%
  \ifthenelse{\equal{ce}{\@@dept}}
    {\@makechapterhead{\uppercase{#2}}}
    {\@makechapterhead{#2}}
  \@afterheading
  \ifthen{\not \boolean{@@inchapters}}
    {
      \pagenumbering{arabic}%
      \@@inchapterstrue
    }
}

