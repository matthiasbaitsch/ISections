library(fs)
library(readxl)
library(jsonlite)
library(tidyverse)

colnames <- read_excel("raw/columns.xlsx") |>
  filter(!is.na(name_neu)) |>
  select(name_neu, name_alt) |>
  deframe()

series <- Vectorize(function(name) {
  p <- str_split_1(name, " ")
  if (length(p) == 2) {
    return(p[1])
  } else {
    return(paste0(p[1], p[3]))
  }
})

read_profiles <- function(file) {
  read_excel(file, skip = 1) |>
    rename(
      property = 1
    ) |>
    pivot_longer(
      !property
    ) |>
    filter(
      property != "S235", property != "S335", property != "S460"
    ) |>
    pivot_wider(
      names_from = property, values_from = value
    ) |>
    select(
      any_of(colnames)
    ) |>
    mutate(
      across(
        .cols = !Name,
        .fns = as.numeric
      )
    ) |>
    mutate(
      Series = series(Name),
      Size = as.integer(str_extract(Name, "\\d+"))
    ) |>
    relocate(
      Series, Size
    )
}

d <- dir_ls("raw/profiles") |>
  map(read_profiles) |>
  bind_rows()

ggplot(data = d, mapping = aes(x = A, y = Iy, color = Series, group = Series)) + 
  geom_line() + geom_point()

write_json(d, "profiles.json", pretty = T, auto_unbox = T)
